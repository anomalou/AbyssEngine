using AbyssLibraries;

namespace AbyssBehavior{
    class MenuLogic:Logic{

        protected action exit, start;
        public MenuLogic(Window parent):base(parent){

        }

        public override void Initialization(){
            exit = Exit;
            start = Start;
            menu.Add("exit", exit);
            menu.Add("start", start);
        }

        protected void Start(){
            Core.OpenWindow(new GameWindow(), parent);
        }

        protected void Exit(){
            Core.Exit();
        }
    }
}