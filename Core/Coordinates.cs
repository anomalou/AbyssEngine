namespace AbyssBehavior{
    public class Transform{
        public class Position{
            int _x;
            int _y;

            public int x{get{return _x;}}
            public int y{get{return _y;}}
            public static implicit operator Position(Vector v){
                return new Position{_x = v.x, _y = v.y};
            }

            public override string ToString(){
                return  _x+"-"+_y;
            }

            public Vector ToVector(){
                return new Vector(_x, _y);
            }

            public static Vector operator+(Vector v, Position p){
                return new Vector(v.x+p._x,v.y+p._y);
            }
            Position(){

            }
        }

        public class Scale{
            int _x;
            int _y;

            public int x{get{return _x;}}
            public int y{get{return _y;}}
            public static implicit operator Scale(Vector v){
                return new Scale{_x = v.x, _y = v.y};
            }
            
            public override string ToString(){
                return  _x+"-"+_y;
            }

            public Vector ToVector(){
                return new Vector(_x, _y);
            }
            Scale(){

            }
        }

        Position _position;
        Scale _scale;
        Scale _maxScale;
        public Position position{get{return _position;}set{_position = value;}}
        public Scale scale{get{return _scale;}}
        public Scale maxScale{get{return _maxScale;}}
        
        public Transform(){
            _position = new Vector();
            _scale = new Vector(1,1);
            _maxScale = new Vector(Core.buffer.width, Core.buffer.height);
        }

        public Transform(Vector position){
            _position = position;
            _maxScale = new Vector(Core.buffer.width, Core.buffer.height);
        }

        public Transform(Vector position, Vector scale){
            _position = position;
            _scale = scale;
            _maxScale = new Vector(Core.buffer.width, Core.buffer.height);
        }

        public void SetScale(Vector scale){
            _scale = scale;
        }

        public void SetMaxScale(Vector scale){
            _maxScale = scale;
        }
    }

    public class Vector{
        int _x;
        int _y;

        public Vector(){
            _x = 0;
            _y = 0;
        }
        public Vector(Vector v){
            _x = v.x;
            _y = v.y;
        }
        public Vector(int x, int y){
            _x = x;
            _y = y;
        }

        public override string ToString(){
                return  _x+"-"+_y;
        }

        public static Vector operator +(Vector v1, Vector v2){
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static bool operator !=(Vector v1, Vector v2){
            if(v1.x != v2.x || v1.y != v2.y)
                return true;
            else
                return false;
        }
        public static bool operator ==(Vector v1, Vector v2){
            if(v1.x == v2.x && v1.y == v2.y)
                return true;
            else
                return false;
        }

        public int x{get{return _x;}}
        public int y{get{return _y;}}

        public static Vector zero(){
            return new Vector(0,0);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
