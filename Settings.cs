﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Settings
    {
        public static int playerCol = 4;
        public static int playerRow = 4;
        public const int StartingHealth = 20;
        public const int MaxPlayerHealth = 60;
        public const int StartingLevel = 1;
        public const int EnemyAtk = 5;
        public const int itemCount = 40;


        public const char DuckChar = '♣';
        public const int DuckCount = 20;
        public const char GooseChar = '+';
        public const int GooseCount = 10;
        public const char LionChar = '&';
        public const int LionCount = 5;
        public const char HealthChar = 'H';
        public const char BuffChar = 'A';
        public const char TeleportChar = 'T';


        public static DateTime lastInputTime = DateTime.MinValue;
        public static TimeSpan inputDelay = TimeSpan.FromSeconds(0.1);
        public static Random random = new Random();
    }
}
