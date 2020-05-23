using System.Collections.Generic;

namespace AbyssBehavior{
    class MainMenu: Window{
        protected override void Initialization(){
            transform.SetupScale(Core.buffer.scale);
            logic = new MenuLogic(this);

            AddWidget("title", new TextBox(new Vector(1,1), new Vector(Core.buffer.scale.x - 2, 1)), "main menu");
            AddMenu("start", new TextBox(new Vector(1, 4), new Vector(10, 1)), "start");
            AddMenu("test1", new TextBox(new Vector(1, 5), new Vector(10, 1)), "test 1");
            AddMenu("test2", new TextBox(new Vector(1, 6), new Vector(10, 1)), "test 2");
            AddMenu("test3", new TextBox(new Vector(1, 7), new Vector(10, 1)), "test 3");
            AddMenu("exit", new TextBox(new Vector(1, 9), new Vector(10, 1)), "exit");
        }

        protected override void PostInitialization(){
            string[,] frame = new string[Core.buffer.scale.x, Core.buffer.scale.y];
            for(int x = 0; x < Core.buffer.scale.x; x++){
                for(int y = 0; y < Core.buffer.scale.y; y++){
                    if(x == 0){
                        frame[x, y] = "L";
                    }else if(x == Core.buffer.scale.x - 1){
                        frame[x, y] = "R";
                    }else if(y == 0){
                        frame[x, y] = "U";
                    }else if(y == Core.buffer.scale.y - 1){
                        frame[x, y] = "D";
                    }else{
                        frame[x, y] = "F";
                    }
                }
            }

            frame[0, 0] = "UL";
            frame[Core.buffer.scale.x - 1, 0] = "UR";
            frame[0, Core.buffer.scale.y - 1] = "DL";
            frame[Core.buffer.scale.x - 1, Core.buffer.scale.y - 1] = "DR";

            canvas.LoadCanvas(frame);
        }
    }
}