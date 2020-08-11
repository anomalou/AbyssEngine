using AbyssLibraries;

namespace AbyssBehavior{
    class GameWindow:Window{
        protected override void Initialization(){
            transform.SetScale(Core.buffer.scale);
            logic = new GameLogic(this);
            DisplayBox displayBox = new DisplayBox();
            displayBox.SetPosition(new Vector(1,1));
            displayBox.SetSize(new Vector(Core.buffer.scale.x/2, Core.buffer.scale.y - 2));
            AddWidget("screen", displayBox);

            ScrollBox scrollBoxTest = new ScrollBox();
            scrollBoxTest.SetPosition(new Vector(Core.buffer.scale.x/2 + 1, 1));
            scrollBoxTest.SetSize(new Vector(10,9));
            AddWidget("scrollBox", scrollBoxTest);

            TextBox text = new TextBox("test");
            TextBox hp = new TextBox("hp");
            hp.SetPosition(new Vector(Core.buffer.scale.x/2 + 10, 1));
            AddWidget("hpBar", hp);

            for(int i = 0; i < 30; i++){
                TextBox t = new TextBox("text"+i);
                AddMenu("text"+i, t);
                scrollBoxTest.AddItem(t);
            }

            text.SetPosition(new Vector(Core.buffer.scale.x/2 + 1, 11));


            AddMenu("text", text);

            // AddWidget("screen", new DisplayBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, Core.buffer.scale.y - 2)));

            SetupBackground(FillBackground());
        }
    }
}