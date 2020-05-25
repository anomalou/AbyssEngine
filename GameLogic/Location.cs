namespace AbyssBehavior{
    class Location{
        Object[,,] location;

        
        public Vector scale{get;}
        public int layers{get;}

        public Location(){
            location = new Object[1,1,1];
            scale = new Vector(1,1);
            layers = 1;
        }

        public Location(int x, int y){
            location = new Object[x,y,1];
            scale = new Vector(x,y);
            layers = 1;
        }

        public Location(int x, int y, int layers){
            location = new Object[x,y,layers];
            scale = new Vector(x,y);
            this.layers = layers;
        }

        public Object GetObject(int x, int y, int l){
            return location[x,y,l];
        }
        public Object GetObject(int x, int y){
            return location[x,y,0];
        }
        public Object GetObject(Vector position){
            return location[position.x, position.y, 0];
        }
        public Object GetObject(Vector position, int layer){
            return location[position.x, position.y, layer];
        }

        public void Set(int x, int y, int layer, string obj){
            location[x,y,layer] = Objects.objects[obj];
        }
        public void Set(int x, int y, string obj){
            location[x,y,0] = Objects.objects[obj];
        }
        public void Set(Vector position, string obj){
            location[position.x, position.y, 0] = Objects.objects[obj];
        }
        public void Set(Vector position, int layer, string obj){
            location[position.x, position.y, layer] = Objects.objects[obj];
        }

        public void Move(Vector to, int toLayer, Object obj){
            if(location[to.x, to.y, toLayer] == null){
                location[to.x, to.y, toLayer] = obj;
                location[obj.position.x, obj.position.y, toLayer] = null;
                obj.position = to;
                obj.layer = toLayer;
            }
        }
    }
}