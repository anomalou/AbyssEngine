using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class Commander : IWindow
    {
        public string name { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public char[,,] content { get; set; }

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
                    Console.SetCursorPosition(positionX + 1, positionY + 3);
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
            text = "V Output V";
            sizeX = 40;
            sizeY = 9;
            output = " ";
            content = new char[sizeX, sizeY, 2];
            CreateWindow();
        }

        void CreateWindow()
        {
            for (int i = 0; i < sizeX; i++)
                for (int t = 0; t < sizeY; t++)
                    content[i, t, 0] = '▓';
            content[0, 0, 0] = '#';
            content[0, 0, 1] = 'Q';
            for(int i = 1; i < sizeX; i++)
            {
                content[i, 0, 0] = '=';
                content[i, 0, 1] = 'Q';
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(text.Length > i)
                {
                    content[i + 1, 5, 0] = text[i];
                    content[i + 1, 5, 1] = 'r';
                }
                content[i + 1, 1, 0] = name[i];
                content[i + 1, 1, 1] = 'b';
            }
            for(int i = 0; i < sizeX - 2; i++)
            {
                content[i + 1, 3, 0] = ' ';
                content[i + 1, 3, 1] = 'W';
                content[i + 1, 7, 0] = ' ';
                content[i + 1, 7, 1] = 'Q';
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
            for (int i = 0; i < sizeX - 2; i++)
            {
                if(output.Length > i) {
                    content[i + 1, 7, 0] = output[i];
                    content[i + 1, 7, 1] = 'Q';
                }
                else
                {
                    content[i + 1, 7, 0] = ' ';
                    content[i + 1, 7, 1] = 'Q';
                }
            }
        }

        void Commands(string com)
        {
            string[] comParts = com.Split(' ');
            if(comParts.Length > 1)
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
                            IWindow w = source.windowLobby("Game");
                            output = w.ReturnValue(new string(val)).ToString();
                        }
                        else
                        {
                            output = comParts[1];
                        }
                        break;
                    case "tp":
                        if(comParts.Length == 3)
                        {
                            GameplayWindow w = source.windowLobby("Game") as GameplayWindow;
                            w.MovePlayer(int.Parse(comParts[1]), int.Parse(comParts[2]));
                        }
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
