namespace AbyssBehavior{
    class GameLogic:Logic{
        action exit, up, down, left, right, setBlock;
        Location location;
        Camera camera;
        Object player;
        public GameLogic(Window parent):base(parent){
            
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
            control.Add(Control.Actions.Deny, exit);
            control.Add(Control.Actions.MoveUp, up);
            control.Add(Control.Actions.MoveDown, down);
            control.Add(Control.Actions.MoveLeft, left);
            control.Add(Control.Actions.MoveRight, right);
            control.Add(Control.Actions.Action, setBlock);
            camera.SetLocation(location);
            camera.SetSpectrate(player);
            for(int x = 0; x < 20; x++){
                for(int y = 0; y < 20; y++){
                    location.Set(new Vector(x,y),0, new Object("grass", "grass", 1));
                }
            }
            
            location.Set(new Vector(1,1),1, player);
            parent.GetWidget("screen").SetData(camera);
        }

        protected override void Update(){
            camera.Update();
        }

        void SetBlock(){
            System.Console.WriteLine("placed!");
            location.Set(new Vector(player.position.x, player.position.y - 1), 1, new Object("bench", "benchH", 10));
        }

        void MoveUp(){
            System.Console.WriteLine("Player pos: " + player.position.x + " " + player.position.y);
            location.Move(new Vector(player.position.x, player.position.y - 1), 1, player);
        }
        void MoveDown(){
            System.Console.WriteLine("Player pos: " + player.position.x + " " + player.position.y);
            location.Move(new Vector(player.position.x, player.position.y + 1), 1, player);
        }
        void MoveLeft(){
            System.Console.WriteLine("Player pos: " + player.position.x + " " + player.position.y);
            location.Move(new Vector(player.position.x - 1, player.position.y), 1, player);
        }
        void MoveRight(){
            System.Console.WriteLine("Player pos: " + player.position.x + " " + player.position.y);
            location.Move(new Vector(player.position.x + 1, player.position.y), 1, player);
        }

        void Exit(){
            Core.CloseWindow(parent);
        }
    }
}