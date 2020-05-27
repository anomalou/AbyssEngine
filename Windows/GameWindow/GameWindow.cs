using System.Collections.Generic;

namespace AbyssBehavior{
    class GameWindow:Window{
        protected override void Initialization(){
            transform.SetupScale(Core.buffer.scale);
            logic = new GameLogic(this);

            AddWidget("screen", new DisplayBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, Core.buffer.scale.y - 2)));
        }

        protected override void PostInitialization(){
            canvas.LoadCanvas(FillBackground());
        }
    }
}