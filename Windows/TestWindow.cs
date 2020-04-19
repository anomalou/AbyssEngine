using System.Collections.Generic;

namespace AbyssBehavior{
    class TestWindow:Window{
        protected override void Initialization(){
            transform.SetupScale(new Vector(40,20));//установить размер окна
            logic = new TestLogic(this);//Заменить на свою логику
            //AddWidget("instruction", new TextBox(new Vector(0,0), new Vector(40,1), ""))
            AddWidget("counter", new TextBox(new Vector(3,1), new Vector(10,1), "0", this), false);
        }
    }
}