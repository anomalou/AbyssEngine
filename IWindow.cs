using System;

namespace ConsoleApplication{
    interface IWindow{

        string name{get;set;}
        char code { get; set; }
        int sizeX{get;set;}
        int sizeY{get;set;}
        int positionX{get;set;}
        int positionY{get;set;}

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
        public static char[,,] Build(int sizeX, int sizeY, string name, char code)
        {
            content = new char[sizeX, sizeY, 2];
            for (int i = 0; i < sizeX; i++)
                for (int t = 0; t < sizeY; t++)
                    content[i, t, 0] = '▓';
            content[0, 0, 0] = code;
            content[0, 0, 1] = 'Q';
            for (int i = 1; i < sizeX; i++)
            {
                content[i, 0, 0] = '=';
                content[i, 0, 1] = 'Q';
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(i + 1 < sizeX)
                {
                    content[i + 1, 1, 0] = name[i];
                    content[i + 1, 1, 1] = 'b';
                }
            }
            return content;
        }
    }
}