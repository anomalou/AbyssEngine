using System;

namespace ConsoleApplication
{
    class Executor : IWindow
    {
        public string name { get; set; }
        public Pixel[,] content { get; set; }
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
            //content = new char[size.X(), size.Y(), 2];
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
                        content[1 + i, 3] = new Pixel(text[1][i], ConsoleColor.Red);
                    }
                    content[size.X() - 4 + i, 3] = new Pixel(text[0][i], ConsoleColor.Blue);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < 2)
                    {
                        content[1 + i, 3] = new Pixel(text[1][i], ConsoleColor.Blue);
                    }
                    content[size.X() - 4 + i, 3] = new Pixel(text[0][i], ConsoleColor.Red);
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
                    content[1 + i, 3] = new Pixel(text[1][i], ConsoleColor.Red);
                }
                content[size.X() - 4 + i, 3] = new Pixel(text[0][i], ConsoleColor.Blue);
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
