using AbyssLibraries;

namespace AbyssBehavior{
    class MenuLogic:Logic{

        protected action exit, start, plugins;

        public MenuLogic(IWindow window):base(window){

        }
        public override void Initialization(){
            exit = Exit;
            start = Start;
            plugins = Plugins;
            menu.Add("exit", exit);
            menu.Add("start", start);
            menu.Add("plugins", plugins);
        }

        protected void Start(){
            Core.OpenWindow(new GameWindow(), window);
        }

        protected void Plugins(){
            Core.OpenWindow(new PluginsList(), window);
        }

        protected void Exit(){
            Core.Exit();
        }
    }
}