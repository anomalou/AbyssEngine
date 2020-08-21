namespace AbyssBehavior{
    public class Buffer{

        // int _width; //ширина
        // int _height; //высота

        // public int width{get{return _width;}}
        // public int height{get{return _height;}}
        
        public Vector scale{get;}

        // int _layers; //слои
        // public int layers{get{return _layers;}}

        Cursore cursore;

        public bool consoleLike;
        
        Point[,,] buffer;

        public Point Get(int x, int y, int depth){
            return buffer[x, y, depth];
        }
        public Buffer(){
            cursore = new Cursore();
            buffer = new Point[ScreenBufferParam.width, ScreenBufferParam.height, ScreenBufferParam.depth];
            scale = new Vector(ScreenBufferParam.width, ScreenBufferParam.height);
            consoleLike = false;
            for(int i = 0; i < ScreenBufferParam.width; i++){
                for(int t = 0; t < ScreenBufferParam.height; t++){
                    for(int f = 0; f < ScreenBufferParam.depth; f++){
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

        // public void SetPoint(Point p){
        //     buffer[cursore.x, cursore.y, cursore.layer].SetupPoint(p);
            
        //     if(consoleLike == true){
        //         cursore.Move();
        //     }
        // }

        public void SetCursore(int x, int y, int layer){
            while(x >= ScreenBufferParam.width || x < 0){
                if(x >= ScreenBufferParam.width){
                    x = x - ScreenBufferParam.width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= ScreenBufferParam.height){
                y = ScreenBufferParam.height;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= ScreenBufferParam.depth)
                layer = ScreenBufferParam.depth;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);
        }

        public void SetCursore(Vector v, int layer){
            int x = v.x;
            int y = v.y;
            while(x >= ScreenBufferParam.width || x < 0){
                if(x > ScreenBufferParam.width){
                    x = x - ScreenBufferParam.width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= ScreenBufferParam.height){
                y = ScreenBufferParam.height;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= ScreenBufferParam.depth)
                layer = ScreenBufferParam.depth;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);

        }

        public void Clear(){
            for(int x = 0; x < ScreenBufferParam.width; x++){
                for(int y = 0; y < ScreenBufferParam.height; y++){
                    for(int l = 0; l < ScreenBufferParam.depth; l++){
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
            //Console.WriteLine(x+" "+y+" "+layer);
        }
        public void Move(){
            _x++;
        }
    }
}