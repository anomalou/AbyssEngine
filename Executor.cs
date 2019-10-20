using System;

namespace ConsoleApplication
{
    class Executor : IWindow
    {
        public string name { get; set; }
        public char[,,] content { get; set; }
        public char code { get; set; }
        public Vector size { get; set; }
        public Vector position { get; set; }

        Source source;

        string[] text;

        bool exit;

        public Executor()
        {
            name = "Want to quit?";
            code = 'E';
            text = new string[2] { "Yes", "No" };
            exit = false;
            size = new Vector(20, 5);
            content = new char[size.X(), size.Y(), 2];
            content = WindowBuilder.Build(size, name, code);
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
                        content[1 + i, 3, 1] = 'r';
                    }
                    content[size.X() - 4 + i, 3, 1] = 'b';
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < 2)
                    {
                        content[1+i, 3, 1] = 'b';
                    }
                    content[size.X() - 4 + i, 3, 1] = 'r';
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
                    content[1 + i, 3, 0] = text[1][i];
                    content[1 + i, 3, 1] = 'r';
                }
                content[size.X() - 4 + i, 3, 0] = text[0][i];
                content[size.X() - 4 + i, 3, 1] = 'b';
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
