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

        Pixel[,] content { get; set; }

        void Start(Source s);

        void Start(Source s, MapManager f);
        void Control(ConsoleKeyInfo key);
        int ReturnValue(string name);
        void Update();
    }

    static class WindowBuilder
    {
        static Pixel[,] content;
        public static Pixel[,] Build(Vector size, string name, char code)
        {
            content = new Pixel[size.X(), size.Y()];
            for (int i = 0; i < size.X(); i++)
                for (int t = 0; t < size.Y(); t++)
                    content[i, t] = new Pixel('▓', ConsoleColor.White);
            content[0, 0] = new Pixel(code, ConsoleColor.DarkGreen);
            for (int i = 1; i < size.X(); i++)
            {
                content[i, 0] = new Pixel('=', ConsoleColor.DarkGreen);
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(i + 1 < size.X())
                {
                    content[i + 1, 1] = new Pixel(name[i], ConsoleColor.Blue);
                }
            }
            return content;
        }
        public static Pixel[,] PrintText(Vector vector, Pixel[,] content, string text, ConsoleColor color)
        {
            Pixel[,] c = content;
            for(int i = 0; i < text.Length; i++)
            {
                if(i < c.Length)
                {
                    c[vector.X() + i, vector.Y()] = new Pixel(text[i],color);
                }
            }
            return c;
        }

        public static Pixel[,] PrintFrame(Vector vector, Vector size, Pixel[,] content){
            Pixel[,] c = content;
            for(int i = 0; i < size.Y(); i++){
                for(int t = 0; t < size.X(); i++){
                    //if(i )
                }
            }
            return c;
        }
    }

    class Pixel{
        ConsoleColor color;
        char graphic;
        public Pixel(){
            color = ConsoleColor.White;
            graphic = '.';
        }

        public Pixel(char character, ConsoleColor color){
            this.color = color;
            graphic = character;
        }

        public ConsoleColor GetColor(){
            return color;
        }

        public char GetCharacter(){
            return graphic;
        }
    }
}