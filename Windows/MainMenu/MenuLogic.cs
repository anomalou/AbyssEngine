using AbyssLibraries;

namespace AbyssBehavior{
    class MenuLogic:Logic{

        protected action test1, exit, start;
        public MenuLogic(Window parent):base(parent){

        }

        public override void Initialization(){
            test1 = OpenTest;
            exit = Exit;
            start = Start;
            menu.Add("test1", test1);
            menu.Add("exit", exit);
            menu.Add("start", start);
        }

        protected void OpenTest(){
            Core.OpenWindow(new TestWindow(), parent);
        }

        protected void Start(){
            Core.OpenWindow(new GameWindow(), parent);
        }

        protected void Exit(){
            Core.Exit();
        }
    }
}