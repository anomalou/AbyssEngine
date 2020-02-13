using System;

namespace AbyssBehaviours
{
    class Colors
    {
        static public ConsoleColor Color(char color)
        {
            switch (color)
            {
                case 'W':
                    return ConsoleColor.White;
                case 'G':
                    return ConsoleColor.DarkGray;
                case 'g':
                    return ConsoleColor.Gray;
                case 'y':
                    return ConsoleColor.Yellow;
                case 'b':
                    return ConsoleColor.Blue;
                case 'r':
                    return ConsoleColor.Red;
                case 'Q':
                    return ConsoleColor.DarkGreen;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
