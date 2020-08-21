using System.Collections.Generic;
using System;

namespace AbyssBehavior{
    public class Logic:IWindowLogic{
        protected delegate void action();
        protected delegate void slot(object package);
        protected IWindow window;

        
        protected action menuUp;
        protected action menuDown;
        protected action menuLeft;
        protected action menuRight;
        protected action select;

        protected string currentMenu;
        KeysToAction.Actions currentAction;
        protected Dictionary<KeysToAction.Actions, action> control;

        protected Dictionary<string, action> menu;

        protected Dictionary<string, slot> connect;
        
        public Logic():this(null){}
        public Logic(IWindow window){
            this.window = window;
            menuUp = MenuUp;
            menuDown = MenuDown;
            menuLeft = MenuLeft;
            menuRight = MenuRight;
            select = Select;
            control = new Dictionary<KeysToAction.Actions, action>();
            menu = new Dictionary<string, action>();
            connect = new Dictionary<string, slot>();
            control.Add(KeysToAction.Actions.CursoreUp, menuUp);
            control.Add(KeysToAction.Actions.CursoreDown, menuDown);
            control.Add(KeysToAction.Actions.CursoreLeft, menuLeft);
            control.Add(KeysToAction.Actions.CursoreRight, menuRight);
            control.Add(KeysToAction.Actions.Accept, select);
        }

        public void SetCurrentAction(KeysToAction.Actions action){
            currentAction = action;
        }
        public void DefaultUpdate(){
            if(window.inFocus){
                if(control.ContainsKey(currentAction))
                    control[currentAction]();
                if(window.selectedElement == null && window.menu.Count > 0)
                    window.selectedElement = window.menu[0];
                if(window.selectedElement != null)
                    currentMenu = window.selectedElement.identificator;
                else
                    currentMenu = "";
                Update();
                SignalsHandler();
                if(Core.errorList.Count > 0){
                    Core.OpenWindow(new ExceptionDesc(), window);
                    EmitSignal("errorMsg", Core.errorList);
                }
            }
        }

        public virtual void Initialization(){

        }
        
        protected virtual void Update(){

        }

        protected void MenuUp(){
            if(window.menu.Count > 0){
                IWidget next = null;
                uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
                Vector position;
                Vector currentPosition;
                currentPosition = new Vector(window.selectedElement.transform.position.x, window.selectedElement.transform.position.y);
                foreach(IWidget widget in window.menu){
                    if(widget.isVisible == true){
                        position = new Vector(widget.transform.position.x, widget.transform.position.y);
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
                    
                }
                if(next != null){
                    if(window.selectedElement != null)
                        window.selectedElement.SetFocus(false);
                    window.selectedElement = next;
                    window.selectedElement.SetFocus(true);
                }

            }
        }
        protected void MenuDown(){
            if(window.menu.Count > 0){
                IWidget next = null;
                uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
                Vector position;
                Vector currentPosition;
                currentPosition = new Vector(window.selectedElement.transform.position.x, window.selectedElement.transform.position.y);
                foreach(IWidget widget in window.menu){
                    if(widget.isVisible == true){
                        position = new Vector(widget.transform.position.x, widget.transform.position.y);
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
                }
                if(next != null){
                    if(window.selectedElement != null)
                        window.selectedElement.SetFocus(false);
                    window.selectedElement = next;
                    window.selectedElement.SetFocus(true);
                }
            }
        }

        protected void MenuLeft(){
            if(window.menu.Count > 0){
                IWidget next = null;
                uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
                Vector position;
                Vector currentPosition;
                currentPosition = new Vector(window.selectedElement.transform.position.x, window.selectedElement.transform.position.y);
                foreach(IWidget widget in window.menu){
                    if(widget.isVisible == true){
                        position = new Vector(widget.transform.position.x, widget.transform.position.y);
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
                }
                if(next != null){
                    if(window.selectedElement != null)
                        window.selectedElement.SetFocus(false);
                    window.selectedElement = next;
                    window.selectedElement.SetFocus(true);
                }
            }
            
        }

        protected void MenuRight(){
            if(window.menu.Count > 0){
                IWidget next = null;
                uint x_d, mx_d = System.Int32.MaxValue, y_d, my_d = System.Int32.MaxValue;
                Vector position;
                Vector currentPosition;
                currentPosition = new Vector(window.selectedElement.transform.position.x, window.selectedElement.transform.position.y);
                foreach(IWidget widget in window.menu){
                    if(widget.isVisible == true){
                        position = new Vector(widget.transform.position.x, widget.transform.position.y);
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
                }
                if(next != null){
                    if(window.selectedElement != null)
                        window.selectedElement.SetFocus(false);
                    window.selectedElement = next;
                    window.selectedElement.SetFocus(true);
                }
            }
            
        }

        protected void Select(){
            if(window.selectedElement != null)
                if(menu.ContainsKey(window.selectedElement.identificator))
                    menu[window.selectedElement.identificator]();
        }

        protected void EmitSignal(string name){
            SwapBuffer.AddInfo(name);
        }

        protected void EmitSignal(string name, object package){
            SwapBuffer.AddInfo(name, package);
        }

        protected void Connect(string name, slot slot){
            connect.Add(name, slot);
        }

        protected void SignalsHandler(){
            foreach(string name in connect.Keys){
                if(SwapBuffer.CheckInfo(name)){
                    connect[name](SwapBuffer.GetInfo(name));
                }
            }
        }
    }
}