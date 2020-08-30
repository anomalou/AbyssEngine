using System.Collections.Generic;
using System.Linq;

namespace AbyssBehavior{

    public static class CanvasFactory{
        public static WidgetCanvas CreateCanvas(Vector size, Vector cellSize){
            if(size.x > 0 && size.y > 0)
                return new WidgetCanvas(size, cellSize);
            else
                return null;
        }
    }
    public class WidgetCanvas{

        protected int _depth;
        public int depth{get{return _depth;}}

        protected int _height;
        public int height{get{return _height;}}
        protected int _width;
        public int width{get{return _width;}}

        protected Layer[] layers;

        protected Vector _size;
        public Vector size{get{return _size;}}

        protected Vector _cellSize;
        public Vector cellSize{get{return _cellSize;}}

        protected Dictionary<byte, byte> _layersEmploy;
        public byte[] layersEmploy{get{return _layersEmploy.Keys.ToArray();}}

        WidgetCanvas(){}
        public WidgetCanvas(Vector size, Vector cellSize){//инициальзация сетки
            _width = size.x;
            _height = size.y;
            _size = new Vector(size);
            _cellSize = new Vector(cellSize);
            _layersEmploy = new Dictionary<byte, byte>();
        }

        public void ReInitialization(Vector size){
            _width = size.x;
            _height = size.y;
            _size = new Vector(size);
            _layersEmploy.Clear();
            layers = null;
        }

        public void ReInitialization(Vector size, Vector cellSize){
            _width = size.x;
            _height = size.y;
            _size = new Vector(size);
            _cellSize = new Vector(cellSize);
            _layersEmploy.Clear();
            layers = null;
        }

        public void Set(int x, int y, byte depth, string texture_name){
            Set(x, y, depth, texture_name, new RGBA());
        }

        public void Set(int x, int y, byte depth, string texture_name, RGBA color){
            if(_layersEmploy.ContainsKey(depth)){
                byte layer = _layersEmploy[depth];
                layers[layer].Set(new Vector(x,y), texture_name, color);
            }else{
                if(layers != null){
                    Layer[] temp = new Layer[layers.Length];
                    for(int i = 0; i < layers.Length; i++)
                        temp[i] = layers[i];
                    layers = new Layer[temp.Length + 1];
                    for(int i = 0; i < temp.Length; i++)
                        layers[i] = temp[i];
                    layers[temp.Length] = new Layer(size);
                    _layersEmploy.Add(depth, (byte)temp.Length);
                }else{
                    layers = new Layer[1];
                    layers[0] = new Layer(size);
                    _layersEmploy.Add(depth, 0);
                }
                byte layer = _layersEmploy[depth];
                layers[layer].Set(new Vector(x,y), texture_name, color);
                _layersEmploy = _layersEmploy.OrderBy(lay => lay.Key).ToDictionary(lay => lay.Key, lay => lay.Value);
            }
        }

        public void Set(int x, int y, byte depth, Point point){
            Set(x, y, depth, point.texture, point.color);
        }

        public Point Get(int x, int y, byte depth){
            if(_layersEmploy.ContainsKey(depth)){
                byte layer = _layersEmploy[depth];
                return layers[layer].Get(new Vector(x,y));
            }else
                return new Point();
        }

        public void Clear(){
            if(layers != null){
                for(int i = 0; i < layers.Length; i++){
                    layers[i] = new Layer(size);
                }
            }
        }
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

    public class Layer{
        protected Point[,] grid;

        protected Vector size;

        Layer(){}

        public Layer(Vector size){
            this.size = size;
            grid = new Point[size.x, size.y];
            for(int x = 0; x < size.x; x++){
                for(int y = 0; y < size.y; y++){
                    grid[x,y] = new Point();
                }
            }
        }

        public void Set(Vector position, string texture, RGBA color){
            if(position < size == true && position >= Vector.zero == true)
                grid[position.x, position.y] = new Point(texture, color);
        }

        public Point Get(Vector position){
            if(position < size && position >= Vector.zero)
                return grid[position.x, position.y];
            else
                return new Point();
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