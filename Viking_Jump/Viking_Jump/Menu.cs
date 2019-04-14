using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Viking_Jump
{
    public static class Menu
    {
        public static int menuTotal;
        private static List<Texture2D> menuTexture = new List<Texture2D>();
        public static int menuSelection;


        private static int [] buttonTotal;
        private static List<Texture2D> buttonTexture = new List<Texture2D>();
        private static Texture2D buttonTextureSelection;
        public static int buttonSelection;
        

        public static int MenuState
        {
            get { return menuSelection; }
            set { menuSelection = value; }
        }

        public static int ButtonSelection
        {
            get { return buttonSelection; }
            set { buttonSelection = value; }
        }


        // Load textures for menu and their buttons. (load content, which menu it shall load the textures, how many buttons that menu have,
        // the X&Y margins from the start position, the space between the buttons, what type of selection {0 = navigation cursor(left), 1 = navigation cursor(right), 2 = an overlay, 3 = an underlay, 4 = replace texture})
        public static void LoadContent(ContentManager content, int menusTotal, int[] buttonsTotal)
        {
            
            // "Constructor"
            menuTotal = menusTotal;
            buttonTotal = buttonsTotal;
            buttonSelection = 0;
            menuSelection = 0;

            // Menu
            for (int menu = 0; menu < menuTotal; menu++)
            {
                menuTexture.Add(content.Load<Texture2D>("Textures/Menu/Menu" + menu));
                // Buttons
                for (int button = 0; button < buttonsTotal[menu]; button++)
                    buttonTexture.Add(content.Load<Texture2D>("Textures/Menu/Menu" + menu + "_button" + button));
            }
            
            // Selection
            buttonTextureSelection = content.Load<Texture2D>("Textures/Menu/Menu_select");

        }


        public static bool Select(int button)
        {
            if(button -1 == buttonSelection && keySelect)
                return true;
            return false;
        }

        public static int previousMenuState = 0;
        public static int currentMenuState = 0;
        public static bool keySelect = false;
        public static bool isKeyUp = true;

        public static void Update(GameTime gameTime)
        {
            previousMenuState = currentMenuState;
            currentMenuState = menuSelection;
            if (currentMenuState != previousMenuState)
                buttonSelection = 0;

            if (Keyboard.GetState().IsKeyUp(Keys.Up) &&
                Keyboard.GetState().IsKeyUp(Keys.Down) &&
                    Keyboard.GetState().IsKeyUp(Keys.Space))
                {
                isKeyUp = true;
            }

            if (buttonTotal[menuSelection] > 0)
            {
                if (buttonSelection > 0)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && isKeyUp == true)
                    {
                        buttonSelection--;
                        isKeyUp = false;
                    }
                }

                if (buttonSelection < buttonTotal[menuSelection] -1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) && isKeyUp == true)
                    {
                        buttonSelection++;
                        isKeyUp = false;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && isKeyUp == true)
                {
                    keySelect = true;
                    isKeyUp = false;
                }
                else keySelect = false;

            }


        }


        
        public static void Draw(SpriteBatch spriteBatch, int marginX, int marginY, int space)
        {
            
            // Menu
            spriteBatch.Draw(menuTexture[menuSelection], new Rectangle(0, 0, Variables.ScreenSize.Width, Variables.ScreenSize.Height), Color.White);
            
            
            // Buttons
            int start = 0;
            for (int i = 0; i < menuSelection; i++)
            {
                start = start + buttonTotal[i];
            }
            for (int i = 0; i < buttonTotal[menuSelection]; i++)
                spriteBatch.Draw(buttonTexture[start+i], new Rectangle(marginX, 
                    marginY + i*(buttonTexture[start+i].Height + space),
                    buttonTexture[i].Width, buttonTexture[i].Height), Color.White);

            // Selection
            spriteBatch.Draw(buttonTextureSelection, new Rectangle(marginX,
                marginY + buttonSelection * (buttonTexture[buttonSelection].Height + space),
                buttonTexture[buttonSelection].Width, buttonTexture[buttonSelection].Height), Color.White);

            
            
        }
        









    }
}
