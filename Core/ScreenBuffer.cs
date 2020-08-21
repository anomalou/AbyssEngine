namespace AbyssBehavior{
    public class ScreenBuffer{

        int _width; //ширина
        int _height; //высота

        public int width{get{return _width;}}
        public int height{get{return _height;}}
        
        public Vector scale{get;}

        int _depth; //слои
        public int depth{get{return _depth;}}

        Cursore cursore;

        public bool consoleLike;
        
        Point[,,] buffer;

        public Point Get(int x, int y, int depth){
            return buffer[x, y, depth];
        }
        public ScreenBuffer(){
            _width = 64;
            _height = 36;
            _depth = 4;
            cursore = new Cursore();
            buffer = new Point[width, height, depth];
            scale = new Vector(width, height);
            consoleLike = false;
            for(int i = 0; i < width; i++){
                for(int t = 0; t < height; t++){
                    for(int f = 0; f < depth; f++){
                        buffer[i,t,f] = new Point();
                    }
                }
            }
        }
        public void Set(){
            buffer[cursore.x, cursore.y, cursore.layer].Setup();
            if(consoleLike == true){
                cursore.Move();
            }
        }
        public void Set(Point point){
            buffer[cursore.x, cursore.y, cursore.layer].Setup(point);
            if(consoleLike == true){
                cursore.Move();
            }
        }

        public void SetCursore(int x, int y, int layer){
            while(x >= width || x < 0){
                if(x >= width){
                    x = x - width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= height){
                y = height;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= depth)
                layer = depth;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);
        }

        public void SetCursore(Vector v, int layer){
            int x = v.x;
            int y = v.y;
            while(x >= width || x < 0){
                if(x > width){
                    x = x - width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= height){
                y = height;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= depth)
                layer = depth;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);

        }

        public void Clear(){
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    for(int l = 0; l < depth; l++){
                        SetCursore(x, y, l);
                        Set();
                    }
                }
            }
        }
    }

    class Cursore{
        int _x;
        int _y;
        int _layer;

        public int x{get{return _x;}}
        public int y{get{return _y;}}
        public int layer{get{return _layer;}}
        public Cursore(){
            _x = 0;
            _y = 0;
            _layer = 0;
        }
        public void chPos(int x, int y, int layer){
            _x = x;
            _y = y;
            _layer = layer;
        }
        public void Move(){
            _x++;
        }
    }
}