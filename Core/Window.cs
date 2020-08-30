using System.Collections.Generic;

namespace AbyssBehavior{
    public class Window:IWindow{
        protected Logic _logic;
        public Logic logic{get{return _logic;}}
        public IWindow parent{get;set;}

        protected bool _inFocus;
        public bool inFocus{get{return _inFocus;}}

        public List<IWidget> widgets{get;}
        public List<IWidget> menu{get;}
        public IWidget selectedElement{get;set;}

        protected Vector _cursorePos;
        protected Vector _cursoreLength;
        public Vector cursorePos{get{return _cursorePos;}}
        public Vector cursoreLength{get{return _cursoreLength;}}


        public Window(){
            widgets = new List<IWidget>();
            menu = new List<IWidget>();
            Initialization();
            if(logic == null){
                // Core.ThrowError(1);
                // Core.CloseWindow(this);
            }
            if(menu.Count != 0){
                selectedElement = menu[0];
                selectedElement.SetFocus(true);
                RenderCursore();
            }else{
                selectedElement = null;
            }
            logic.Initialization();
        }

        //Пользовательский метод инциальзации. Его можно переписать под себя
        protected virtual void Initialization(){
            
        }

        //Метод которые производит обновление содержимого и виджетов окна.
        public void DefaultUpdate(){
            if(inFocus){
                if(logic != null)
                    logic.DefaultUpdate();
                else
                    Core.CloseWindow(this);
                foreach(IWidget w in widgets){
                    w.Update();
                }
                Update();
                RenderCursore();
                RenderWidgets();
            }
        }

        protected virtual void Update(){

        }

        protected void SetLogic(Logic logic){
            _logic = logic;
        }

        public void SetFocus(bool state){
            _inFocus = state;
        }

        //Метод добавления нового виджета на окно
        public void AddWidget(string name, IWidget widget){
            foreach(IWidget w in widgets){
                if(w.identificator == name)
                    return;
            }
            widget.identificator = name;
            widgets.Add(widget);
        }

        public void AddMenu(string name, IWidget widget){
            foreach(IWidget w in widgets){
                if(w.identificator == name)
                    return;
            }
            widget.identificator = name;
            widgets.Add(widget);
            menu.Add(widget);
        }


        public TWidget GetWidget<TWidget>(string identificator) where TWidget : IWidget{
            foreach(IWidget w in widgets){
                if(w.identificator == identificator)
                    return (TWidget)w;
            }
            return default(TWidget);
        }

        public void RemoveWidget(string name){
            foreach(IWidget w in widgets){
                if(w.identificator == name){
                    foreach(IWidget child in w.children){
                        child.parent = null;
                    }
                    w.children.Clear();
                    widgets.Remove(w);
                    if(menu.Contains(w))
                        menu.Remove(w);
                }
            }

        }

        void RenderWidgets(){
            
        }

        void RenderCursore(){
            if(selectedElement != null && menu.Contains(selectedElement)){
                Vector pos,scale;
                pos = new Vector((int)selectedElement.transform.position.x, (int)selectedElement.transform.position.y);
                scale = new Vector(selectedElement.transform.scale.x, selectedElement.transform.scale.y);
                _cursorePos = new Vector(pos + new Vector(0, scale.y * selectedElement.canvas.cellSize.y - selectedElement.canvas.cellSize.y));
                _cursoreLength =  new Vector(pos + scale * selectedElement.canvas.cellSize - selectedElement.canvas.cellSize);
            }
        }

        protected void SetupBackground(string[,] canvas){
            
        }

    }
}
