using System;

namespace AbyssBehaviours{
    interface IWindow {

        string name { get; set; }
        char code { get; set; }
        int WID{ get; set; } // window ID
        //int sizeX{get;set;}
        //int sizeY{get;set;}
        //int positionX{get;set;}
        //int positionY{get;set;}

        Vector size { get; set; }
        Vector position { get; set; }

        //Pixel[,] content { get; set; }
        WindowContainer container {get; set;}

        void Start(Source s);
        void Start(Source s, MapManager map);
        void Control(ConsoleKeyInfo key);
        int ReturnValue(string name);
        void Update();
    }

    class WindowContainer{
        Pixel[,] content;
        Vector size;

        public WindowContainer(Vector size){
            this.size = size;
            content = new Pixel[size.X(), size.Y()];
        }

        public void SetPixel(Vector position, Pixel pixel){
            content[position.X(), position.Y()] = pixel;
        }

        public Pixel GetPixel(Vector position){
            return content[position.X(), position.Y()];
        }

        public int X(){
            return size.X();
        }

        public int Y(){
            return size.Y();
        }
    }

    static class WindowBuilder
    {
        public enum State{
            Fill,
            Frame
        }
        static WindowContainer content;
        public static WindowContainer Build(Vector size, string name, char code, State state )
        {
            content = new WindowContainer(size);
            for (int i = 0; i < size.X(); i++)
                for (int t = 0; t < size.Y(); t++)
                    content.SetPixel(new Vector(i,t), new Pixel('▓', ConsoleColor.White));
            content.SetPixel(new Vector(0,0), new Pixel(code, ConsoleColor.DarkGreen));
            for (int i = 1; i < size.X(); i++)
            {
                content.SetPixel(new Vector(i,0), new Pixel('=', ConsoleColor.DarkGreen));
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(i + 1 < size.X())
                {
                    content.SetPixel(new Vector(i+1,1), new Pixel(name[i], ConsoleColor.Blue));
                }
            }
            if(state == State.Frame){
                for(int i = 3; i < size.Y() - 1; i++){
                    for(int t = 1; t < size.X() - 1; t++){
                        content.SetPixel(new Vector(t,i), new Pixel(' ', ConsoleColor.White));
                    }
                }
            }
            return content;
        }
        public static WindowContainer PrintText(Vector position, WindowContainer container, int textLength, string text, object color)
        {
            for(int i = 0, x = 0, y = 0; i < textLength; i++)
            {
                if(i < text.Length)
                    container.SetPixel(new Vector(position.X() + x, position.Y() + y), new Pixel(text[i],color));
                else
                    container.SetPixel(new Vector(position.X() + x, position.Y() + y), new Pixel(' ',color));
                if(x < container.X() && x < textLength)
                    x++;
                else if(x >= container.X() || x >= textLength){
                    x = 0;
                    y = y + 1;
                }
            }
            return container;
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
            graphic = ' ';
        }

        public Pixel(char character, object color){
            this.color = (ConsoleColor)color;
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