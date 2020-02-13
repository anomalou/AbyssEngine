using System;
using System.Collections.Generic;
using System.Text;

namespace AbyssBehaviours
{
    class Commander : IWindow
    {
        public string name { get; set; }
        //public Pixel[,] content { get; set; }
        public WindowContainer container {get;set;}
        public char code { get; set; }
        public Vector size { get; set; }
        public Vector position { get; set; }
        public int WID { get; set; }

        Source source;
        string command;
        string output;

        string text;

        public void Control(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(position.X() + 1, position.Y() + 3);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    command = Console.ReadLine();
                    Console.ResetColor();
                    Commands(command);
                    break;
                case ConsoleKey.Escape:
                    source.CloseWindow(source.GetActive());
                break;
            }
        }

        public Commander()
        {
            name = "/Command line/";
            code = '>';
            text = "V Output V";
            size = new Vector(40, 9);
            output = " ";
            CreateWindow();
        }

        void CreateWindow()
        {
            container = WindowBuilder.Build(size, name, code, WindowBuilder.State.Fill);
            container = WindowBuilder.PrintText(new Vector(1, 5), container, 10, text, ConsoleColor.DarkGreen);
            /*for (int i = 0; i < sizeX; i++)
                for (int t = 0; t < sizeY; t++)
                    content[i, t, 0] = '▓';
            content[0, 0, 0] = '>';
            content[0, 0, 1] = 'Q';
            for(int i = 1; i < sizeX; i++)
            {
                content[i, 0, 0] = '=';
                content[i, 0, 1] = 'Q';
            }
            for (int i = 0; i < name.Length; i++)
            {
                content[i + 1, 1, 0] = name[i];
                content[i + 1, 1, 1] = 'b';
            }*/
            /*if (text.Length > i)
            {
                content[i + 1, 5, 0] = text[i];
                content[i + 1, 5, 1] = 'r';
            }*/
            for (int i = 0; i < size.X() - 2; i++)
            {
                container.SetPixel(new Vector(i + 1, 3), new Pixel(' ', ConsoleColor.White));
                container.SetPixel(new Vector(i + 1, 7), new Pixel(' ', ConsoleColor.White));
            }
        }

        public void Start(Source s, MapManager f)
        {
            
        }

        public void Start(Source s)
        {
            source = s;
        }

        public void Update()
        {
            for (int i = 0; i < size.X() - 2; i++)
            {
                if(output.Length > i) {
                    container.SetPixel(new Vector(i + 1, 7), new Pixel(output[i], ConsoleColor.DarkGreen));
                }
                else
                {
                    container.SetPixel(new Vector(i + 1, 7), new Pixel(' ', ConsoleColor.DarkGreen));
                }
            }
        }

        void Commands(string com)
        {
            string[] comParts = com.Split(' ');
            if(comParts.Length > 1 && comParts[1].Length > 0)
            {
                switch (comParts[0])
                {
                    case "print":
                        if (comParts[1][0] == '&')
                        {
                            char[] val = new char[comParts[1].Length - 1];
                            for (int i = 0; i < val.Length; i++)
                            {
                                val[i] = comParts[1][i + 1];
                            }
                            for (int i = 0; i < val.Length; i++)
                            {
                                val[i] = comParts[1][i + 1];
                            }
                            IWindow w = source.windowLobby(0);
                            if(w != null)
                                output = w.ReturnValue(new string(val)).ToString();
                            else
                                source.AddDebug("(C)Error window not founded!");
                        }
                        else
                        {
                            output = comParts[1];
                        }
                        break;
                    case "tp":
                        if(comParts.Length == 3)
                        {
                            GameplayWindow w = source.windowLobby(0) as GameplayWindow;
                            w.MovePlayer(new Vector(int.Parse(comParts[1]), int.Parse(comParts[2])));
                        }
                        break;
                }
            }else if(comParts.Length == 1){
                switch(comParts[0]){
                    case ".output":
                        source.CloseWindow(source.GetActive());
                        source.OpenWindow(new Vector(0,0),new Output());
                    break;
                }
            }
        }

        public int ReturnValue(string name)
        {
            return -1;
        }
    }
}
