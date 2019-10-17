using System;

namespace ConsoleApplication
{
    class Executor : IWindow
    {
        public string name { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public char[,,] content { get; set; }
        public char code { get; set; }

        Source source;

        string[] text;

        bool exit;

        public Executor()
        {
            name = "Want to quit?";
            code = 'E';
            text = new string[2] { "Yes", "No" };
            exit = false;
            sizeX = 20;
            sizeY = 5;
            content = new char[sizeX, sizeY, 2];
            content = WindowBuilder.Build(sizeX, sizeY, name, code);
        }

        public void Control(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    exit = !exit;
                    Highlight();
                    break;
                case ConsoleKey.RightArrow:
                    exit = !exit;
                    Highlight();
                    break;
                case ConsoleKey.Enter:
                    if (exit == true)
                        source.Exit();
                    else
                        source.CloseWindow(source.GetActive());
                    break;
                case ConsoleKey.Escape:
                    source.CloseWindow(source.GetActive());
                    break;
            }
        }

        void Highlight()
        {
            if(exit == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < 2)
                    {
                        content[1 + i, 4, 1] = 'r';
                    }
                    content[sizeX - 4 + i, 4, 1] = 'b';
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < 2)
                    {
                        content[1+i, 4, 1] = 'b';
                    }
                    content[sizeX - 4 + i, 4, 1] = 'r';
                }
            }
            
        }

        public int ReturnValue(string name)
        {
            return -1;
        }

        public void Start(Source s)
        {
            source = s;
            for(int i = 0; i < 3; i++)
            {
                if(i < 2)
                {
                    content[1 + i, 4, 0] = text[1][i];
                    content[1 + i, 4, 1] = 'r';
                }
                content[sizeX - 4 + i, 4, 0] = text[0][i];
                content[sizeX - 4 + i, 4, 1] = 'b';
            }
        }

        public void Start(Source s, MapManager f)
        {
            
        }

        public void Update()
        {
            
        }
    }
}
