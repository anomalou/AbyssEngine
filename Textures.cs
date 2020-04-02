using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace AbyssBehavior{
    class Textures{
        int _textureNumber;
        public int textureNumber{get{return _textureNumber;}}
        Texture[] _textures;
        public Texture[] textures{get{return _textures;}}
        public Textures(){//иниацилизация и загрузка из файла имена текстур и их символы
            _textures = new Texture[textureNumber];
            for(int i = 0; i < textureNumber; i++){
                _textures[i] = new Texture();
            }
        }       
    }

    class Texture{
        Texture2D _texture;
        string _name;

        public string name{get{return _name;}}
        public Texture2D texture{get{return _texture;}}

        public Texture(){
            _name = "null";
        }
        public Texture(Texture2D texture, string name){
            _texture = texture;
            _name = name;
        }
    }
}