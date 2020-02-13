using System;
using System.Text.Json;
using System.IO;

namespace AbyssBehaviours{
    class MapEditor : IWindow
    {
        public string name { get; set; }
        public char code { get; set; }
        public Vector size { get; set; }
        public Vector position { get; set; }
        public WindowContainer container { get; set; }
        public int WID { get; set; }

        public void Control(ConsoleKeyInfo key)
        {
            switch(key.Key){
                case ConsoleKey.N:
                break;
                case ConsoleKey.Escape:
                break;
            }
        }

        public int ReturnValue(string name)
        {
           return -1;
        }

        public void Start(Source s)
        {
           
        }

        public void Start(Source s, MapManager map)
        {
           
        }

        public void Update()
        {
           
        }
    }
}