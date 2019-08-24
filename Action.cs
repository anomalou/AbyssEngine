using System;

namespace ConsoleApplication{

    class BaseAction{//base action for the most objects
        public virtual void Action(int x,int y,Source s){}
    }
    class OpenDoor:BaseAction{//soon with this class you will can open doors
        public override void Action(int x,int y,Source s){
            s.RemoveObj(x,y);
        }
    }
}