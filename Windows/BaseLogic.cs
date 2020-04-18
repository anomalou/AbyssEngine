using System.Collections.Generic;

namespace AbyssBehavior{
    class Logic{
        protected delegate void action();
        protected Window parent;

        
        protected action menuUp;
        protected action menuDown;

        protected Dictionary<Control.Actions, action> control;

        protected bool wait;
        public int waitTime;
        
        public Logic(Window parent = null){
            this.parent = parent;
            menuUp = MenuUp;
            menuDown = MenuDown;
            control = new Dictionary<Control.Actions, action>();
            wait = false;
            waitTime = 0;
            control.Add(Control.Actions.CursoreUp, menuUp);
            control.Add(Control.Actions.CursoreDown, menuDown);
        }
        public void DefaultUpdate(){
            if(control.ContainsKey(Control.action)){
                control[Control.action]();
            }
            Update();
        }
        
        protected virtual void Update(){

        }

        protected void MenuUp(){
            int index;
            if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
                index = parent.menu.IndexOf(parent.selectedElement);
                if(index - 1 < 0){
                    parent.selectedElement = parent.menu[parent.menu.Count - 1];
                }else{
                    parent.selectedElement = parent.menu[index - 1];
                }
            }else{
                Core.ThrowError(2);
            }
        }
        protected void MenuDown(){
            int index;
            if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
                index = parent.menu.IndexOf(parent.selectedElement);
                if(index + 1 >= parent.menu.Count){
                    parent.selectedElement = parent.menu[0];
                }else{
                    parent.selectedElement = parent.menu[index + 1];
                }
            }else{
                Core.ThrowError(3);
            }
        }
    }
}