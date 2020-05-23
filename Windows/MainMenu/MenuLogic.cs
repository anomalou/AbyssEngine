using System.Collections.Generic;

namespace AbyssBehavior{
    class MenuLogic:Logic{

        protected action test1, exit;
        public MenuLogic(Window parent):base(parent){

        }

        protected override void Initalization(){
            test1 = OpenTest;
            exit = Exit;
            menu.Add("test1", test1);
            menu.Add("exit", exit);
        }

        protected void OpenTest(){
            Core.OpenWindow(new TestWindow(), parent);
        }

        protected void Exit(){
            Core.Exit();
        }
    }
}