using System;

namespace AbyssBehaviours{

    class BaseAction{//base action for the most objects
        public virtual void Action(Vector vector,GameplayWindow w){}
    }
    class OpenDoor:BaseAction{//soon with this class you will can open doors
        public override void Action(Vector vector,GameplayWindow w){
            w.RemoveObj(vector);
        }
    }
    class ActivateTrap : BaseAction
    {
        public override void Action(Vector vector, GameplayWindow w)
        {
            w.DegreeHp(10);
            w.inventory.SetItem(1);
            w.source.AddDebug("action");
        }
    }
}