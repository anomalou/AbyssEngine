using System.Collections.Generic;

namespace AbyssBehavior{
    class MainMenu: Window{
        protected override void Initialization(){
            transform.SetupScale(Core.buffer.scale);
            logic = new MenuLogic(this);

            AddWidget("title", new TextBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, 1)), "main menu");
            AddWidget("icon", new Image(new Vector(11,1)), "player");
            AddMenu("start", new TextBox(new Vector(1, 4), new Vector(10, 1)), "start");
            AddMenu("test1", new TextBox(new Vector(1, 5), new Vector(10, 1)), "test 1");
            AddMenu("test2", new TextBox(new Vector(1, 6), new Vector(10, 1)), "test 2");
            AddMenu("test3", new TextBox(new Vector(1, 7), new Vector(10, 1)), "test 3");
            AddMenu("exit", new TextBox(new Vector(1, 9), new Vector(10, 1)), "exit");
        }

        protected override void PostInitialization(){
            canvas.LoadCanvas(FillBackground());
        }
    }
}