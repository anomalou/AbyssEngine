using System.Collections.Generic;

namespace AbyssBehavior{
    public class Widget:IWidget{

        public string name{get;set;}
        public Transform transform{get;}
        public WidgetCanvas canvas{get;}


        // widget parametrs

        public IWidget parent{get;set;}
        public List<IWidget> children{get;}

        protected bool _isVisible;
        public bool isVisible{get{return _isVisible;}}

        protected bool _inFocus;
        public bool inFocus{get{return _inFocus;}}

        protected int _layer;
        public int layer{get{return _layer;}}

        public Widget(){
            transform = new Transform(new Vector(0,0), new Vector(1,1));
            children = new List<IWidget>();
            _isVisible = true;
            _inFocus = false;
            _layer = 0;
            canvas = CanvasFactory.CreateWidgetCanvas(transform.scale.x, transform.scale.y);
        }

        public Point GetPoint(int x, int y, int depth){
            return canvas.Get(x,y,depth);
        }

        public void Update(){
            canvas.Clear();
            Behaviour();
            Render();
        }

        public void SetSize(Vector size){
            transform.SetScale(size);
            canvas.ReInitialization(size.x, size.y);
        }

        public void SetVisible(bool state){
            _isVisible = state;
        }

        public void SetFocus(bool state){
            _inFocus = state;
        }

        public void SetPosition(Vector position){
            transform.position = position;
        }

        public virtual void SetData(object data){
            
        }

        protected virtual void Behaviour(){

        }

        protected virtual void Render(){

        }

        public void SetParent(IWidget parent){
            if(parent != null){
                if(this.parent != null){
                    if(this.parent.name == parent.name)
                        return;
                }
                this.parent = parent;
                parent.AddChild(this);
            }
        }

        public void RemoveParent(){
            if(parent != null){
                if(parent.children.Contains(this))
                    parent.children.Remove(this);
                parent = null;
            }
        }

        public void AddChild(IWidget child){
            if(child != null){
                if(!children.Contains(child)){
                    children.Add(child);
                    child.SetParent(this);
                }
            }
        }

        public void RemoveChild(string childName){
            foreach(IWidget w in children){
                if(w.name == childName){
                    w.parent = null;
                    children.Remove(w);
                }
            }
        }

        public void RemoveChild(IWidget child){
            if(children.Contains(child)){
                child.parent = null;
                children.Remove(child);
            }
        }

        public IWidget GetChild(string name){
            foreach(IWidget w in children){
                if(w.name == name)
                    return w;
            }
            return null;
        }

        public IWidget[] GetChildren(){
            return children.ToArray();
        }

    }
}