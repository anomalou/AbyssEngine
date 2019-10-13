using System;

namespace ConsoleApplication
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
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
