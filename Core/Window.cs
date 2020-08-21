using System.Collections.Generic;

namespace AbyssBehavior{
    public class Window:IWindow{
        public Transform transform{get;}

        protected string[,] background;
        public Canvas canvas{get;}

        protected Logic _logic;
        public Logic logic{get{return _logic;}}
        public IWindow parent{get;set;}

        protected bool _inFocus;
        public bool inFocus{get{return _inFocus;}}

        public List<IWidget> widgets{get;}
        public List<IWidget> menu{get;}
        public IWidget selectedElement{get;set;}


        public Window():this(Vector.zero()){}

        public Window(Vector position){
            transform = new Transform(position);
            widgets = new List<IWidget>();
            menu = new List<IWidget>();
            Initialization();
            if(transform.scale != null)
                canvas = CanvasFactory.CreateCanvas(transform.scale.x, transform.scale.y);
            else
                canvas = CanvasFactory.CreateCanvas(1, 1);
            if(logic == null){
                // Core.ThrowError(1);
                // Core.CloseWindow(this);
            }
            if(menu.Count != 0){
                selectedElement = menu[0];
                selectedElement.SetFocus(true);
            }else{
                selectedElement = null;
            }
            logic.Initialization();
            canvas.LoadCanvas(background);
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
                ClearLayers();
                RenderWidgets();
                RenderCursore();
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

        void ClearLayers(){
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    for(int l = 1; l < canvas.depth; l++){
                        canvas.Set(x,y,l,"null");
                    }
                }
            }
        }

        void RenderWidgets(){
            foreach(IWidget w in widgets){
                if(w.isVisible == true){
                    for(int x = 0; x < w.transform.scale.x; x++){
                        if(x+w.transform.position.x < transform.scale.x){
                            for(int y = 0; y < w.transform.scale.y; y++){
                                if(y+w.transform.position.y < transform.scale.y){
                                    for(int l = 0; l < w.canvas.depth; l++){
                                        canvas.Set(x+w.transform.position.x,y+w.transform.position.y, l+1, w.GetPoint(x,y,l));
                                    }

                                }
                                else
                                    break;
                            }
                        }else
                            break;
                    }
                }
            }
        }

        void RenderCursore(){
            if(selectedElement != null && menu.Contains(selectedElement)){
                Vector pos,scale;
                pos = new Vector(selectedElement.transform.position.x, selectedElement.transform.position.y);
                scale = new Vector(selectedElement.transform.scale.x, selectedElement.transform.scale.y);
                canvas.Set(pos.x, pos.y + scale.y - 1, 3, "cursoreL");
                canvas.Set(pos.x+scale.x - 1, pos.y+scale.y - 1, 3, "cursoreR");
            }
        }

        protected void SetupBackground(string[,] canvas){
            background = new string[transform.scale.x, transform.scale.y];
            if(canvas.Length <= transform.scale.x * transform.scale.y)
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    background[x,y] = canvas[x,y];
                }
            }
        }

        protected string[,] FillBackground(){
            string[,] canvas = new string[transform.scale.x, transform.scale.y];
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    if(x == 0){
                        canvas[x, y] = "L";
                    }else if(x == transform.scale.x - 1){
                        canvas[x, y] = "R";
                    }else if(y == 0){
                        canvas[x, y] = "U";
                    }else if(y == transform.scale.y - 1){
                        canvas[x, y] = "D";
                    }else{
                        canvas[x, y] = "F";
                    }
                }
            }

            canvas[0, 0] = "UL";
            canvas[transform.scale.x - 1, 0] = "UR";
            canvas[0, transform.scale.y - 1] = "DL";
            canvas[transform.scale.x - 1, transform.scale.y - 1] = "DR";
            return canvas;
        }
    }
}
