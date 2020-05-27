namespace AbyssBehavior{
    class Location{
        Object[,,] location;

        Object empty;
        
        public Vector scale{get;}
        public int layers{get;}

        public Location(){
            empty = new Object("null", "null", 1000);
            location = new Object[1,1,1];
            scale = new Vector(1,1);
            layers = 1;
            for(int x = 0; x < scale.x; x++){
                for(int y = 0; y < scale.y; y++){
                    for(int l = 0; l < layers; l++){
                        Set(new Vector(x,y),l,new Object("null", "null", 1000));
                    }
                }
            }
        }

        public Location(int x, int y){
            empty = new Object("null", "null", 1000);
            location = new Object[x,y,1];
            scale = new Vector(x,y);
            layers = 1;
            for(int _x = 0; _x < scale.x; _x++){
                for(int _y = 0; _y < scale.y; _y++){
                    for(int l = 0; l < layers; l++){
                        Set(new Vector(_x,_y),l,new Object("null", "null", 1000));
                    }
                }
            }
        }

        public Location(int x, int y, int layers){
            empty = new Object("null", "null", 1000);
            location = new Object[x,y,layers];
            scale = new Vector(x,y);
            this.layers = layers;
            for(int _x = 0; _x < scale.x; _x++){
                for(int _y = 0; _y < scale.y; _y++){
                    for(int l = 0; l < layers; l++){
                        Set(new Vector(_x,_y),l,new Object("null", "null", 1000));
                    }
                }
            }
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
            if(Objects.objects.ContainsKey(obj))
                location[x,y,layer] = Objects.objects[obj];
        }
        public void Set(int x, int y, string obj){
            if(Objects.objects.ContainsKey(obj))
                location[x,y,0] = Objects.objects[obj];
        }
        public void Set(Vector position, string obj){
            if(Objects.objects.ContainsKey(obj))
                location[position.x, position.y, 0] = Objects.objects[obj];
        }
        public void Set(Vector position, int layer, string obj){
            if(Objects.objects.ContainsKey(obj))
                location[position.x, position.y, layer] = Objects.objects[obj];
        }

        public void Set(Vector position, int layer, Object obj){
            if(position.x > -1 && position.x < scale.x && position.y > -1 && position.y < scale.y && layer > -1 && layer < layers){
                obj.position = new Vector(position);
                obj.layer = layer;
                location[position.x, position.y, layer] = obj;
            }
            
        }

        public void Move(Vector to, int toLayer, Object obj){
            if(to.x < scale.x && to.x > -1 && to.y < scale.y && to.y > -1){
                if(location[to.x, to.y, toLayer].name == empty.name){
                    location[to.x, to.y, toLayer] = obj;
                    location[obj.position.x, obj.position.y, obj.layer] = new Object("null", "null", 1000);
                    obj.position = to;
                    obj.layer = toLayer;
                }
            }
        }
    }
}