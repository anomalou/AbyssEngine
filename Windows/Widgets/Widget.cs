namespace AbyssBehavior{
    class Widget{

        protected int _layers;
        public int layers{get{return _layers;}}
        public Transform transform;
        protected Point [,,] canvas;


        // widget parametrs

        protected bool _isVisible;
        public bool isVisible{get{return _isVisible;}}

        protected bool _inFocus;
        public bool inFocus{get{return _inFocus;}}

        public Widget(){
            transform = new Transform(new Vector(0,0), new Vector(1,1));
            _isVisible = true;
            _inFocus = false;
            Initializtion();
        }

        // public Widget(Vector position){
        //     transform = new Transform(position, new Vector(1,1));
        //     Initializtion();
        // }

        // public Widget(Vector position, Vector scale){
        //     transform = new Transform(position, scale);
        //     Initializtion();
        // }

        public string GetPoint(int x, int y, int l){
            return canvas[x, y, l].texture;
        }

        void Initializtion(){
            _layers = Core.buffer.layers - 2;
            canvas = new Point[transform.scale.x, transform.scale.y, _layers];
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    for(int l = 0; l < _layers; l++){
                        canvas[x,y,l] = new Point();
                    }
                }
            }
        }

        public void Update(){
            ClearCanvas();
            Behaviour();
            Render();
        }

        void ClearCanvas(){
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    for(int l = 0; l < layers; l++){
                        canvas[x,y,l].SetupPoint("null");
                    }
                }
            }
        }

        public void SetSize(Vector size){
            transform.SetupScale(size);
            Initializtion();
        }

        public void SetVisible(bool state){
            _isVisible = state;
        }

        public void SetInFocus(bool state){
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
    }
}