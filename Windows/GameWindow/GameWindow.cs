using System.Collections.Generic;

namespace AbyssBehavior{
    class GameWindow:Window{
        protected override void Initialization(){
            transform.SetupScale(Core.buffer.scale);
            logic = new GameLogic(this);
            DisplayBox displayBox = new DisplayBox();
            displayBox.SetPosition(new Vector(1,1));
            displayBox.SetSize(new Vector(Core.buffer.scale.x - 2, Core.buffer.scale.y - 2));
            AddWidget("screen", displayBox);

            // AddWidget("screen", new DisplayBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, Core.buffer.scale.y - 2)));

            SetupBackground(FillBackground());
        }
    }
}