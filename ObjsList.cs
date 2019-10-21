using System;

namespace ConsoleApplication{
    class ObjsList{ //class that have array with all objects which are you can meet on you way

        public Obj Objs(char c){
            Obj o = new Obj();
            o.symbol = c;
            switch(c){
                case '.':
                    o.name = "Void";
                    o.use = false;
                    o.color = ConsoleColor.White;
                    o.impassible = false; 
                    o.behaviour = new BaseAction();
                    return o;
                case ',':
                    o.name = "Trap";
                    o.use = true;
                    o.color = ConsoleColor.Gray;
                    o.impassible = false;
                    o.behaviour = new ActivateTrap();
                    return o;
                case '─':
                    o.name = "Horizontal wall";
                    o.use = false;
                    o.color = ConsoleColor.White;
                    o.impassible = true; 
                    o.behaviour = new BaseAction();
                    return o;
                case '|':
                    o.name = "Vertical wall";
                    o.use = false;
                    o.color = ConsoleColor.White;
                    o.impassible = true; 
                    o.behaviour = new BaseAction();
                    return o;
                case '#':
                    o.name = "Door";
                    o.use = true;
                    o.color = ConsoleColor.DarkYellow;
                    o.impassible = true; 
                    o.behaviour = new OpenDoor();
                    return o;
                case '@':
                    o.name = "Player";
                    o.use = false;
                    o.color = ConsoleColor.Green;
                    o.impassible = false; 
                    o.behaviour = new BaseAction();
                    return o;
                default:
                    o.name = " ";
                    o.use = false;
                    o.color = ConsoleColor.White;
                    o.impassible = false;
                    o.behaviour = new BaseAction();
                    return o;
            }
        }
    }
}