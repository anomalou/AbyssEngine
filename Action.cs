using System;

namespace ConsoleApplication{

    class BaseAction:Source{//base action for the most objects
        public virtual void Action(int x,int y){}
    }
    class OpenDoor:BaseAction{//soon with this class you will can open doors
        public override void Action(int x,int y){
            source.RemoveObj(x,y);
        }
    }
}