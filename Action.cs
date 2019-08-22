using System;

namespace ConsoleApplication{

    public class BaseAction{//base action for the most objects
        public virtual void Action(){}
    }
    class OpenDoor:BaseAction{//soon with this class you will can open doors
        public override void Action(){
            Console.Write("Yep");
        }
    }
}