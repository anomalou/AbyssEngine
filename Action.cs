using System;

namespace ConsoleApplication{

    class BaseAction{//base action for the most objects
        public virtual void Action(int x,int y,GameplayWindow w){}
    }
    class OpenDoor:BaseAction{//soon with this class you will can open doors
        public override void Action(int x,int y,GameplayWindow w){
            w.RemoveObj(x,y);
        }
    }
    class ActivateTrap : BaseAction
    {
        public override void Action(int x, int y, GameplayWindow w)
        {
            w.DegreeHp(10);
        }
    }
}