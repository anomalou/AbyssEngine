using System;

namespace AbyssBehaviours{
    class Output : IWindow
    {
        public string name { get; set; }
        public char code { get; set; }
        public Vector size { get; set; }
        public Vector position { get; set; }
        //public Pixel[,] content { get; set; }
        public WindowContainer container {get;set;}
        public int WID { get; set; }

        Source source;
        public Output(){
            name = "Output";
            code = 'V';
            size = new Vector(30,28);
            container = WindowBuilder.Build(size, name, code, WindowBuilder.State.Frame);
        }

        public void Control(ConsoleKeyInfo key)
        {
            switch(key.Key){
                case ConsoleKey.Escape:
                case ConsoleKey.Enter:
                    source.CloseWindow(source.GetActive());
                break;
            }
        }

        public int ReturnValue(string name)
        {
            return -1;
        }

        public void Start(Source s)
        {
            source = s;
            for(int i = 1; i < 25; i++){
                container = WindowBuilder.PrintText(new Vector(1,3+i-1), container, 10, i + ")", ConsoleColor.Red);
                container = WindowBuilder.PrintText(new Vector(4,3+i-1), container, 25, source.GetDebug(i-1), ConsoleColor.Red);
            }
        }

        public void Start(Source s, MapManager map)
        {
            
        }

        public void Update()
        {

        }
    }
}