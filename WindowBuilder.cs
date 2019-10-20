using System;

namespace ConsoleApplication{
    interface IWindow {

        string name { get; set; }
        char code { get; set; }
        //int sizeX{get;set;}
        //int sizeY{get;set;}
        //int positionX{get;set;}
        //int positionY{get;set;}

        Vector size { get; set; }
        Vector position { get; set; }

        char[,,] content { get; set; }

        void Start(Source s);

        void Start(Source s, MapManager f);
        void Control(ConsoleKeyInfo key);
        int ReturnValue(string name);
        void Update();
    }

    static class WindowBuilder
    {
        static char[,,] content;
        public static char[,,] Build(Vector size, string name, char code)
        {
            content = new char[size.X(), size.Y(), 2];
            for (int i = 0; i < size.X(); i++)
                for (int t = 0; t < size.Y(); t++)
                    content[i, t, 0] = '▓';
            content[0, 0, 0] = code;
            content[0, 0, 1] = 'Q';
            for (int i = 1; i < size.X(); i++)
            {
                content[i, 0, 0] = '=';
                content[i, 0, 1] = 'Q';
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(i + 1 < size.X())
                {
                    content[i + 1, 1, 0] = name[i];
                    content[i + 1, 1, 1] = 'b';
                }
            }
            return content;
        }
        public static char[,,] PrintText(Vector vector, char[,,] content, string text, char color)
        {
            char[,,] c = content;
            for(int i = 0; i < text.Length; i++)
            {
                if(i < content.Length)
                {
                    content[vector.X() + i, vector.Y(), 0] = text[i];
                    content[vector.X() + i, vector.Y(), 1] = color;
                }
            }
            return c;
        }
    }
}