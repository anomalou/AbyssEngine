using System.Collections.Generic;

namespace AbyssBehavior{
    class MainMenu: Window{
        protected override void Initialization(){
            transform.SetupScale(Core.buffer.scale);
            logic = new MenuLogic(this);
            TextBox title = new TextBox("main menu");
            title.SetPosition(new Vector(1,1));
            title.SetSize(new Vector(Core.buffer.scale.x - 2, 1));
            Image icon = new Image("player");
            icon.SetPosition(new Vector(11,1));
            TextBox start = new TextBox("start");
            TextBox test1 = new TextBox("display box");
            TextBox test2 = new TextBox("counter");
            TextBox exit = new TextBox("exit");
            start.SetPosition(new Vector(1, 4));
            start.SizeToText();
            test1.SetPosition(new Vector(1, 5));
            test1.SizeToText();
            test2.SetPosition(new Vector(1, 6));
            test2.SizeToText();
            exit.SetPosition(new Vector(1, 9));
            exit.SizeToText();
            AddWidget("title", title);
            AddWidget("icon", icon);
            AddMenu("start", start);
            AddMenu("test1", test1);
            AddMenu("test2", test2);
            AddMenu("exit", exit);

            // AddWidget("title", new TextBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, 1)), "main menu");
            // AddWidget("icon", new Image(new Vector(11,1)), "player");
            // AddMenu("start", new TextBox(new Vector(1, 4), new Vector(10, 1)), "start");
            // AddMenu("test1", new TextBox(new Vector(1, 5), new Vector(10, 1)), "test 1");
            // AddMenu("test2", new TextBox(new Vector(1, 6), new Vector(10, 1)), "test 2");
            // AddMenu("test3", new TextBox(new Vector(1, 7), new Vector(10, 1)), "test 3");
            // AddMenu("exit", new TextBox(new Vector(1, 9), new Vector(10, 1)), "exit");

            // canvas.LoadCanvas(FillBackground());
            SetupBackground(FillBackground());
        }
    }
}