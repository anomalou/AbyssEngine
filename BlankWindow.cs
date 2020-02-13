using System;

namespace AbyssBehaviours{
    class BlankWindow : IWindow
    {
        public string name { get; set; }
        public char code { get; set; }
        public Vector size { get; set; }
        public Vector position { get; set; }
        public WindowContainer container { get; set; }
        public int WID { get; set; }

        public BlankWindow(){
            WID = -1;
        }

        public void Control(ConsoleKeyInfo key)
        {
            
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