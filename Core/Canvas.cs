namespace AbyssBehavior{

    public static class CanvasFactory{
        public static Canvas CreateCanvas(int width = 0, int height = 0){
            if(width > 0 && height > 0)
                return new Canvas(width, height, ScreenBufferParam.depth);
            else
                return null;
        }

        public static WidgetCanvas CreateWidgetCanvas(int width = 0, int height = 0){
            if(width > 0 && height > 0)
                return new WidgetCanvas(width, height, ScreenBufferParam.depth - 2);
            else
                return null;
        }
    }
    public class Canvas{

        protected int _depth;
        public int depth{get{return _depth;}}

        protected int _height;
        public int height{get{return _height;}}
        protected int _width;
        public int width{get{return _width;}}
        protected Point[,,] canvas;

        protected Vector _scale;
        public Vector scale{get{return _scale;}}

        Canvas(){}
        public Canvas(int width, int height, int depth){//инициальзация сетки
            this._height = height;
            this._width = width;
            _scale = new Vector(width, height);
            _depth = depth;
            canvas = new Point[width, height, depth];
            for(int i = 0; i < width; i++){
                for(int t = 0; t < height; t++){
                    for(int f = 0; f < depth; f++){
                        canvas[i,t,f] = new Point();
                    }
                }
            }
        }

        public void ReInitialization(int width, int height){//инициальзация сетки
            this._height = height;
            this._width = width;
            _scale = new Vector(width, height);
            canvas = new Point[width, height, depth];
            for(int i = 0; i < width; i++){
                for(int t = 0; t < height; t++){
                    for(int f = 0; f < depth; f++){
                        canvas[i,t,f] = new Point();
                    }
                }
            }
        }

        public void LoadCanvas(string[,] textures){
            if(textures.Length == canvas.Length / depth){
                for(int x = 0; x < width; x++){
                    for(int y = 0; y < height; y++){
                        canvas[x,y,0].Setup(textures[x,y]);
                    }
                }
            }
        }

        public void Set(int x, int y, int depth, string texture_name){
            if(x > -1 && x < scale.x && y > -1 && y < scale.y && depth > -1 && depth < this.depth)
                canvas[x, y, depth].Setup(texture_name);
        }

        public void Set(int x, int y, int depth, string texture_name, RGBA color){
            if(x > -1 && x < scale.x && y > -1 && y < scale.y && depth > -1 && depth < this.depth)
                canvas[x, y, depth].Setup(texture_name, color);
        }

        public void Set(int x, int y, int depth, Point point){
            if(x > -1 && x < scale.x && y > -1 && y < scale.y && depth > -1 && depth < this.depth)
                canvas[x, y, depth].Setup(point.texture, point.color);
        }

        public Point Get(int x, int y, int depth){
            if(x > -1 && x < scale.x && y > -1 && y < scale.y && depth > -1 && depth < this.depth)
                return canvas[x, y, depth];
            else
                return new Point();
        }

        public void Clear(){
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    for(int depth = 0; depth < this.depth; depth++){
                        canvas[x,y,depth].Setup();
                    }
                }
            }
        }
    }

    public class WidgetCanvas:Canvas{
        public WidgetCanvas(int width, int height, int depth):base(width, height, depth){}
    }


    ///<summary>
    ///Allow use colors in rgba mode. Colors takes value between 0..255
    ///</summary>
    public class RGBA{
        uint r;
        uint g;
        uint b;
        uint a;
        uint _color;
        public uint R{get{return r;}}
        public uint G{get{return g;}}
        public uint B{get{return b;}}
        public uint A{get{return a;}}
        public uint color{get{return _color;}}


        public RGBA(){
            SetRGBA(255, 255, 255, 255);
        }
        public RGBA(uint r, uint g, uint b, uint a){
            SetRGBA(r, g, b, a);
        }

        public RGBA(RGBA color){
            SetRGBA(color);
        }

        ///<summary>
        ///Set your color.
        ///</summary>
        public void SetRGBA(uint r, uint g, uint b, uint a){
            if(r < 256)
                this.r = r;
            else
                this.r = 255;
            if(g < 256)
                this.g = g;
            else
                this.g = 255;
            if(b < 256)
                this.b = b;
            else
                this.b = 255;
            if(a < 256)
                this.a = a;
            else
                this.a = 255;
            _color = r + (g << 8) + (b << 16) + (a << 24);
        }

        public void SetRGBA(RGBA color){
            r = color.R;
            g = color.G;
            b = color.B;
            _color = color.color;
        }
    }

    public class Point{
        string texture_name;

        public string texture{get{return texture_name;}}

        RGBA _color;
        

        public RGBA color{get{return _color;}}

        public Point(){
            texture_name = "null";
            _color = new RGBA();
        }
        public Point(string texture_name){
            this.texture_name = texture_name;
            _color = new RGBA();
        }

        public Point(string texture_name, RGBA color){
            this.texture_name = texture_name;
            _color = new RGBA(color);
        }

        public void Setup(){
            texture_name = "null";
            _color.SetRGBA(255, 255, 255, 255);
        }
        public void Setup(string texture_name){
            this.texture_name = texture_name;
            _color.SetRGBA(255, 255, 255, 255);
        }
        public void Setup(string texture_name, RGBA color){
            this.texture_name = texture_name;
            _color.SetRGBA(color);
        }

        public void Setup(Point point){
            Setup(point.texture, point.color);
        }

        // public void SetupPoint(Point p){
        //     color = p.color;
        //     texture_name = p.texture_name;
        // }
    }
}