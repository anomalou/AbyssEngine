using System;

namespace ConsoleApplication{
    class ObjsList{ //class that have array with all objects which are you can meet on you way
        public Obj[] obj;
        public ObjsList(){
            obj = new Obj[101]; //how many objects do you have?
            obj[0] = new Obj(){name = "Void",symbol = ' ',use = false,impassible = false, behaviour = new BaseAction()};
            obj[1] = new Obj(){name = "Horizontal wall",symbol = '\u2501',use = false,impassible = true, behaviour = new BaseAction()};
            obj[2] = new Obj(){name = "Vertical wall",symbol = '\u2502',use = false,impassible = true, behaviour = new BaseAction()};
            obj[3] = new Obj(){name = "Left up angle",symbol = '\u250f',use = false,impassible = true, behaviour = new BaseAction()};
            obj[4] = new Obj(){name = "Right up angle",symbol = '\u2513',use = false,impassible = true, behaviour = new BaseAction()};
            obj[5] = new Obj(){name = "Left down angle",symbol = '\u2517',use = false,impassible = true, behaviour = new BaseAction()};
            obj[6] = new Obj(){name = "Right down angle",symbol = '\u251b',use = false,impassible = true, behaviour = new BaseAction()};
            obj[7] = new Obj(){name = "Left crossroad",symbol = '\u251d',use = false,impassible = true, behaviour = new BaseAction()};
            obj[8] = new Obj(){name = "Right crossroad",symbol = '\u2525',use = false,impassible = true, behaviour = new BaseAction()};
            obj[9] = new Obj(){name = "Up crossroad",symbol = '\u252f',use = false,impassible = true, behaviour = new BaseAction()};
            obj[10] = new Obj(){name = "Down crossroad",symbol = '\u253b',use = false,impassible = true, behaviour = new BaseAction()};
            obj[11] = new Obj(){name = "Cross",symbol = '\u254b',use = false,impassible = true, behaviour = new BaseAction()};
            obj[12] = new Obj(){name = "Horizontal door",symbol = '\u2509',use = true,impassible = true, behaviour = new OpenDoor()};
            obj[13] = new Obj(){name = "Vertical door",symbol = '\u250b',use = true,impassible = true, behaviour = new OpenDoor()};
            obj[100] = new Obj(){name = "Player",symbol = '@',use = false,impassible = true, behaviour = new BaseAction()};
        }
    }
}