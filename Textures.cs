using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AbyssBehavior{
    class Textures{
        // int _textureNumber;
        // public int textureNumber{get{return _textureNumber;}}
        // Texture[] _textures;
        // public Texture[] textures{get{return _textures;}}
        public Dictionary<string, Texture2D> _textures;
        public Dictionary<string, string> textures;
        

        public Textures(){
            _textures = new Dictionary<string, Texture2D>();
            textures = new Dictionary<string, string>();
            AddTexture("notexture", "notexture");
            AddTexture("null", "null");
            Initialization();
        }

        void Initialization(){
            AddTexture("cursoreL", "cursoreL");
            AddTexture("cursoreR", "cursoreR");

            AddTexture("UL","windows_parts/UL");
            AddTexture("U","windows_parts/U");
            AddTexture("UR","windows_parts/UR");
            AddTexture("L","windows_parts/L");
            AddTexture("F","windows_parts/F");
            AddTexture("R","windows_parts/R");
            AddTexture("DL","windows_parts/DL");
            AddTexture("D","windows_parts/D");
            AddTexture("DR","windows_parts/DR");
            AddTexture("IUL","windows_parts/IUL");
            AddTexture("IUR","windows_parts/IUR");
            AddTexture("IU","windows_parts/IU");
            AddTexture("IL","windows_parts/IL");
            AddTexture("IR","windows_parts/IR");
            AddTexture("IDL","windows_parts/IDL");
            AddTexture("ID","windows_parts/ID");
            AddTexture("IDR","windows_parts/IDR");
            AddTexture("IOUL","windows_parts/IOUL");
            AddTexture("IOUR","windows_parts/IOUR");
            AddTexture("IOU","windows_parts/IOU");
            AddTexture("IOL","windows_parts/IOL");
            AddTexture("IOR","windows_parts/IOR");
            AddTexture("IOD","windows_parts/IOD");
            AddTexture("IODL","windows_parts/IODL");
            AddTexture("IODR","windows_parts/IODR");

            AddTexture("word0", "words/word0");
            AddTexture("word1", "words/word1");
            AddTexture("word2", "words/word2");
            AddTexture("word3", "words/word3");
            AddTexture("word4", "words/word4");
            AddTexture("word5", "words/word5");
            AddTexture("word6", "words/word6");
            AddTexture("word7", "words/word7");
            AddTexture("word8", "words/word8");
            AddTexture("word9", "words/word9");

            AddTexture("worda", "words/worda");
            AddTexture("wordb", "words/wordb");
            AddTexture("wordc", "words/wordc");
            AddTexture("wordd", "words/wordd");
            AddTexture("worde", "words/worde");
            AddTexture("wordf", "words/wordf");
            AddTexture("wordg", "words/wordg");
            AddTexture("wordh", "words/wordh");
            AddTexture("wordi", "words/wordi");
            AddTexture("wordk", "words/wordk");
            AddTexture("wordl", "words/wordl");
            AddTexture("wordm", "words/wordm");
            AddTexture("wordn", "words/wordn");
            AddTexture("wordo", "words/wordo");
            AddTexture("wordp", "words/wordp");
            AddTexture("wordq", "words/wordq");
            AddTexture("wordr", "words/wordr");
            AddTexture("words", "words/words");
            AddTexture("wordt", "words/wordt");
            AddTexture("wordu", "words/wordu");
            AddTexture("wordv", "words/wordv");
            AddTexture("wordw", "words/wordw");
            AddTexture("wordx", "words/wordx");
            AddTexture("wordy", "words/wordy");
            AddTexture("wordz", "words/wordz");
            AddTexture("word ", "words/word ");

            AddTexture("abyss", "textures/abyss");
            AddTexture("dark", "textures/dark");
            AddTexture("player", "textures/player");
            AddTexture("grass", "textures/grass");
            AddTexture("benchH", "textures/benchH");
            AddTexture("benchV", "textures/benchV");
        }

        void AddTexture(string name, string path){
            textures.Add(name, path);
        }

        // public Textures(){//иниацилизация и загрузка из файла имена текстур и их символы
        //     // _textures = new Texture[textureNumber];
        //     // for(int i = 0; i < textureNumber; i++){
        //     //     _textures[i] = new Texture();
        //     // }
        // }       
    }

    // class Texture{
    //     Texture2D _texture;
    //     string _name;

    //     public string name{get{return _name;}}
    //     public Texture2D texture{get{return _texture;}}

    //     public Texture(){
    //         _name = "null";
    //     }
    //     public Texture(Texture2D texture, string name){
    //         _texture = texture;
    //         _name = name;
    //     }
    // }
}