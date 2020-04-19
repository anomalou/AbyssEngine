namespace AbyssBehavior{
    class Widget{

        public Transform transform;
        protected Point [,] canvas;

        protected Window parent;

        public Widget(){
            transform = new Transform(new Vector(0,0), new Vector(1,1));
            parent = null;
            Initializtion();
        }

        public Widget(Vector position, Vector scale, Window parent = null){
            transform = new Transform(position, scale);
            if(parent != null)
                this.parent = parent;
            Initializtion();
        }

        public string GetPoint(Vector pos){
            return canvas[pos.x, pos.y].texture;
        }

        void Initializtion(){
            canvas = new Point[transform.scale.x, transform.scale.y];
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    canvas[x,y] = new Point();
                }
            }
        }

        public void Update(){
            ClearCanvas();
            Behaviour();
        }

        void ClearCanvas(){
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    canvas[x,y].SetupPoint("null");
                }
            }
        }

        public virtual void SetData(object data){

        }

        protected virtual void Behaviour(){

        }
    }
}