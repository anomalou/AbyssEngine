namespace ConsoleApplication{
    class Obj{//property of every object
        public string name;//name of object
        public char symbol;//symbol of object
        public bool impassible;//impassible or not. If true that the object impassible, if false that not
        public bool use;//can you use that object? if true is yes you can, if false you can't
        //public int count;
        //public int ID;
        public BaseAction behaviour;//using with use field. have referens to void of behaviour
    }
}