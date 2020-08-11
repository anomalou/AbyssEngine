using AbyssLibraries;

namespace AbyssBehavior{
    class GameLogic:Logic{
        action exit, up, down, left, right, setBlock;
        Location location;
        Camera camera;
        Object player;
        public GameLogic(Window window):base(window){
            
        }

        public override void Initialization(){
            location = new Location(20, 20, 2);
            camera = new Camera(new Vector(Core.buffer.scale.x/2, Core.buffer.scale.y - 2));
            player = new Object("player", "player", 100);
            exit = Exit;
            up = MoveUp;
            down = MoveDown;
            left = MoveLeft;
            right = MoveRight;
            setBlock = SetBlock;
            control.Add(KeysToAction.Actions.Deny, exit);
            control.Add(KeysToAction.Actions.MoveUp, up);
            control.Add(KeysToAction.Actions.MoveDown, down);
            control.Add(KeysToAction.Actions.MoveLeft, left);
            control.Add(KeysToAction.Actions.MoveRight, right);
            control.Add(KeysToAction.Actions.Action, setBlock);
            camera.SetLocation(location);
            camera.SetSpectrate(player);
            for(int x = 0; x < 20; x++){
                for(int y = 0; y < 20; y++){
                    location.Set(new Vector(x,y),0, new Object("grass", "grass", 1));
                }
            }
            
            location.Set(new Vector(1,1),1, player);
            window.GetWidget("screen").SetData(camera);
        }

        protected override void Update(){
            camera.Update();
            if(GameCore.gameRuleControl.GetStat("hp") != null)
                window.GetWidget("hpBar").SetData(GameCore.gameRuleControl.GetStat("hp").value);
            else{
                Core.CloseWindow(window);
                Core.OpenWindow(new ErrorWithPlugin(), window.parent);
            }
        }

        void SetBlock(){
            // location.Set(new Vector(player.position.x, player.position.y - 1), 1, new Object("bench", "benchH", 10));
            GameCore.gameRuleControl.GetStat("hp").SubValue(1);
        }

        void MoveUp(){
            location.Move(new Vector(player.position.x, player.position.y - 1), 1, player);
        }
        void MoveDown(){
            location.Move(new Vector(player.position.x, player.position.y + 1), 1, player);
        }
        void MoveLeft(){
            location.Move(new Vector(player.position.x - 1, player.position.y), 1, player);
        }
        void MoveRight(){
            location.Move(new Vector(player.position.x + 1, player.position.y), 1, player);
        }

        void Exit(){
            Core.CloseWindow(window);
        }
    }
}