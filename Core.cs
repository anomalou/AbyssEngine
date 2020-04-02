using Microsoft.Xna.Framework.Input;

namespace AbyssBehavior{
    static class Core{

        public static Time time;

        public static Buffer buffer;
        static void Main(string[] arg)
        {
            Initialization();
        }

        static void Initialization(){
            buffer = new Buffer();
            using (var graphic = new GraphicRender())
                graphic.Run();
        }

        public static void Update(){
            Render();
            
        }

        static void Render(){

        }

        static void OpenWindow(){
            
        }

        static void OpenWindow(Vector position){

        }

        static void OpenInfo(string text){

        }

        //управление


    }

    static class Control{
        public static Keys[] pressedKeys;
        
    }

    class Transform{
        public class Position{
            int _x;
            int _y;
            public static implicit operator Position(Vector v){
                return new Position{_x = v.x, _y = v.y};
            }

            public override string ToString(){
                return  _x+"-"+_y;
            }

            Position(){

            }
        }

        public class Scale{
            int _x;
            int _y;
            public static implicit operator Scale(Vector v){
                return new Scale{_x = v.x, _y = v.y};
            }
            
            public override string ToString(){
                return  _x+"-"+_y;
            }
            Scale(){

            }
        }

        Position _position;
        Scale _scale;
        public Position position{get{return _position;}set{_position = value;}}
        public Scale scale{get{return _scale;}}

        
        public Transform(){
            _position = new Vector();
            _scale = new Vector(1,1);
        }

        public Transform(Vector position, Vector scale){
            _position = position;
            _scale = scale;
        }

    }

    class Vector{
        int _x;
        int _y;

        public Vector(){
            _x = 0;
            _y = 0;
        }
        public Vector(int x, int y){
            _x = x;
            _y = y;
        }

        public int x{get{return _x;}}
        public int y{get{return _y;}}

        public static Vector zero(){
            return new Vector(0,0);
        }
    }

    class Time{

        int msc;
        int seconds;
        int minutes;
        int hours;
    }
}