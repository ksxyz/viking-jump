using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Viking_Jump
{
    public static class Variables
    {
        private static Rectangle screenSize = new Rectangle(0, 0, 700, 900);
        private static float fontSize = 1f;

        private static int playerSpeedVertical = 0;
        private static int playerSpeedHorizontal = 0;
        private static int playerChargePotential = 1000;
        private static int playerCollisionMargin = 40;
        private static int playerGravitation = 0;

        private static int platformSpawnGap = 500; //Random
        private static int platformSpawnRate = 1;

        private static int totalPlatformTextures = 4;
        private static int totalBackgroundTextures = 13;

        private static int backgroundLevelLeangth = 1;
        private static int backgroundLevelRepeat = 300;

        private static float lavaSpeed = 1f;








        public static int PlayerSpeedVertical
        {
            get { return playerSpeedVertical; }
            set { playerSpeedVertical = value; }
        }

        public static int PlayerSpeedHorizontal
        {
            get { return playerSpeedHorizontal; }
            set { playerSpeedHorizontal = value; }
        }

        public static int PlayerChargePotential
        {
            get { return playerChargePotential; }
            set { playerChargePotential = value; }
        }

        public static int PlayerGravitation
        {
            get { return playerGravitation; }
            set { playerGravitation = value; }
        }

        public static int PlatformSpawnGap
        {
            get { return platformSpawnGap; }
            set { platformSpawnGap = value; }
        }

        public static int PlatformSpawnRate
        {
            get { return platformSpawnRate; }
            set { platformSpawnRate = value; }
        }

        public static int TotalPlatformTextures
        {
            get { return totalPlatformTextures; }
            set { totalPlatformTextures = value; }
        }

        public static int TotalBackgroundTextures
        {
            get { return totalBackgroundTextures; }
            set { totalBackgroundTextures = value; }
        }

        public static int BackgroundLevelLeangth
        {
            get { return backgroundLevelLeangth; }
            set { backgroundLevelLeangth = value; }
        }

        public static int BackgroundLevelRepeat
        {
            get { return backgroundLevelRepeat; }
            set { backgroundLevelRepeat = value; }
        }

        public static float LavaSpeed
        {
            get { return lavaSpeed; }
            set { lavaSpeed = value; }
        }

        public static Rectangle ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }

        public static float FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        public static int PlayerCollisionMargin
        {
            get { return playerCollisionMargin; }
            set { playerCollisionMargin = value; }
        }


    }

}
