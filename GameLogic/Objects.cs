using System.Collections.Generic;

namespace AbyssBehavior{
    class Object{
        string _name;

        public Vector position;
        public int layer;
        public string name{get{return _name;}}
        string _texture;
        public string texture{get{return _texture;}}
        int _durability;
        public int durability{get{return _durability;}}

        public Object(string name, string texture, int durability){
            _name = name;
            _texture = texture;
            _durability = durability;
        }

        public Object(string name, string texture){
            _name = name;
            _texture = texture;
            _durability = 1;
        }

        public Object(string name){
            _name = name;
            _texture = "abyss";
            _durability = 10000;
        }

        public void DealDamage(int damage){
            _durability -= damage;
        }
    }

    static class Objects{
        public static Dictionary<string, Object> objects;

        public static void Initalization(){
            objects = new Dictionary<string, Object>();
            /////////////////////////////////////////////


        }
    }
}