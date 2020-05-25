using System.Collections.Generic;

namespace AbyssBehavior{
    class Logic{
        protected delegate void action();
        protected Window parent;

        
        protected action menuUp;
        protected action menuDown;
        protected action menuLeft;
        protected action menuRight;
        protected action select;

        protected Dictionary<Control.Actions, action> control;

        protected Dictionary<string, action> menu;

        public Logic(Window parent){
            this.parent = parent;
            menuUp = MenuUp;
            menuDown = MenuDown;
            menuLeft = MenuLeft;
            menuRight = MenuRight;
            select = Select;
            control = new Dictionary<Control.Actions, action>();
            menu = new Dictionary<string, action>();
            control.Add(Control.Actions.CursoreUp, menuUp);
            control.Add(Control.Actions.CursoreDown, menuDown);
            control.Add(Control.Actions.CursoreLeft, menuLeft);
            control.Add(Control.Actions.CursoreRight, menuRight);
            control.Add(Control.Actions.Accept, select);
            Initalization();
        }
        public void DefaultUpdate(){
            if(Core.currentWindow == parent){
                if(control.ContainsKey(Control.action)){
                control[Control.action]();
                }
                Update();
            }
        }

        protected virtual void Initalization(){

        }
        
        protected virtual void Update(){

        }

        protected void MenuUp(){
            string next = "null";
            uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
            Vector position;
            Vector currentPosition;
            currentPosition = new Vector(parent.GetWidget(parent.selectedElement).transform.position.x, parent.GetWidget(parent.selectedElement).transform.position.y);
            foreach(var widget in parent.menu){
                position = new Vector(parent.GetWidget(widget).transform.position.x, parent.GetWidget(widget).transform.position.y);
                if(position.y < currentPosition.y){
                    x_d = (uint)System.Math.Abs(currentPosition.x - position.x);
                    y_d = (uint)System.Math.Abs(currentPosition.y - position.y);
                    if(x_d <= mx_d && y_d <= my_d){
                        mx_d = x_d;
                        my_d = y_d;
                        next = widget;
                    }
                }
            }
            if(next != "null")
                parent.selectedElement = next;

            // int index;
            // if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
            //     index = parent.menu.IndexOf(parent.selectedElement);
            //     if(index - 1 < 0){
            //         parent.selectedElement = parent.menu[parent.menu.Count - 1];
            //     }else{
            //         parent.selectedElement = parent.menu[index - 1];
            //     }
            // }else{
            //     Core.ThrowError(2);
            // }
        }
        protected void MenuDown(){
            string next = "null";
            uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
            Vector position;
            Vector currentPosition;
            currentPosition = new Vector(parent.GetWidget(parent.selectedElement).transform.position.x, parent.GetWidget(parent.selectedElement).transform.position.y);
            foreach(var widget in parent.menu){
                position = new Vector(parent.GetWidget(widget).transform.position.x, parent.GetWidget(widget).transform.position.y);
                if(position.y > currentPosition.y){
                    x_d = (uint)System.Math.Abs(currentPosition.x - position.x);
                    y_d = (uint)System.Math.Abs(currentPosition.y - position.y);
                    if(x_d <= mx_d && y_d <= my_d){
                        mx_d = x_d;
                        my_d = y_d;
                        next = widget;
                    }
                }
            }
            if(next != "null")
                parent.selectedElement = next;

            // int index;
            // if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
            //     index = parent.menu.IndexOf(parent.selectedElement);
            //     if(index + 1 >= parent.menu.Count){
            //         parent.selectedElement = parent.menu[0];
            //     }else{
            //         parent.selectedElement = parent.menu[index + 1];
            //     }
            // }else{
            //     Core.ThrowError(3);
            // }
        }

        protected void MenuLeft(){
            string next = "null";
            uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
            Vector position;
            Vector currentPosition;
            currentPosition = new Vector(parent.GetWidget(parent.selectedElement).transform.position.x, parent.GetWidget(parent.selectedElement).transform.position.y);
            foreach(var widget in parent.menu){
                position = new Vector(parent.GetWidget(widget).transform.position.x, parent.GetWidget(widget).transform.position.y);
                if(position.x < currentPosition.x){
                    x_d = (uint)System.Math.Abs(currentPosition.x - position.x);
                    y_d = (uint)System.Math.Abs(currentPosition.y - position.y);
                    if(x_d <= mx_d && y_d <= my_d){
                        mx_d = x_d;
                        my_d = y_d;
                        next = widget;
                    }
                }
            }
            if(next != "null")
                parent.selectedElement = next;
        }

        protected void MenuRight(){
            string next = "null";
            uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
            Vector position;
            Vector currentPosition;
            currentPosition = new Vector(parent.GetWidget(parent.selectedElement).transform.position.x, parent.GetWidget(parent.selectedElement).transform.position.y);
            foreach(var widget in parent.menu){
                position = new Vector(parent.GetWidget(widget).transform.position.x, parent.GetWidget(widget).transform.position.y);
                if(position.x > currentPosition.x){
                    x_d = (uint)System.Math.Abs(currentPosition.x - position.x);
                    y_d = (uint)System.Math.Abs(currentPosition.y - position.y);
                    if(x_d <= mx_d && y_d <= my_d){
                        mx_d = x_d;
                        my_d = y_d;
                        next = widget;
                    }
                }
            }
            if(next != "null")
                parent.selectedElement = next;
        }

        protected void Select(){
            if(menu.ContainsKey(parent.selectedElement)){
                menu[parent.selectedElement]();
            }else
                Core.ThrowError(6);
        }
    }
}