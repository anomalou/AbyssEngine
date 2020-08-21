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

            // AddTexture("word0", "words/word0");

            AddTexture("wordA_", "font/wordA_");
            AddTexture("wordB_", "font/wordB_");
            AddTexture("wordC_", "font/wordC_");
            AddTexture("wordD_", "font/wordD_");
            AddTexture("wordE_", "font/wordE_");
            AddTexture("wordF_", "font/wordF_");
            AddTexture("wordG_", "font/wordG_");
            AddTexture("wordH_", "font/wordH_");
            AddTexture("wordI_", "font/wordI_");
            AddTexture("wordJ_", "font/wordJ_");
            AddTexture("wordK_", "font/wordK_");
            AddTexture("wordL_", "font/wordL_");
            AddTexture("wordM_", "font/wordM_");
            AddTexture("wordN_", "font/wordN_");
            AddTexture("wordO_", "font/wordO_");
            AddTexture("wordP_", "font/wordP_");
            AddTexture("wordQ_", "font/wordQ_");
            AddTexture("wordR_", "font/wordR_");
            AddTexture("wordS_", "font/wordS_");
            AddTexture("wordT_", "font/wordT_");
            AddTexture("wordU_", "font/wordU_");
            AddTexture("wordV_", "font/wordV_");
            AddTexture("wordW_", "font/wordW_");
            AddTexture("wordX_", "font/wordX_");
            AddTexture("wordY_", "font/wordY_");
            AddTexture("wordZ_", "font/wordZ_");
            AddTexture("wordA", "font/wordA");
            AddTexture("wordB", "font/wordB");
            AddTexture("wordC", "font/wordC");
            AddTexture("wordD", "font/wordD");
            AddTexture("wordE", "font/wordE");
            AddTexture("wordF", "font/wordF");
            AddTexture("wordG", "font/wordG");
            AddTexture("wordH", "font/wordH");
            AddTexture("wordI", "font/wordI");
            AddTexture("wordJ", "font/wordJ");
            AddTexture("wordK", "font/wordK");
            AddTexture("wordL", "font/wordL");
            AddTexture("wordM", "font/wordM");
            AddTexture("wordN", "font/wordN");
            AddTexture("wordO", "font/wordO");
            AddTexture("wordP", "font/wordP");
            AddTexture("wordQ", "font/wordQ");
            AddTexture("wordR", "font/wordR");
            AddTexture("wordS", "font/wordS");
            AddTexture("wordT", "font/wordT");
            AddTexture("wordU", "font/wordU");
            AddTexture("wordV", "font/wordV");
            AddTexture("wordW", "font/wordW");
            AddTexture("wordX", "font/wordX");
            AddTexture("wordY", "font/wordY");
            AddTexture("wordZ", "font/wordZ");
            AddTexture("word0", "font/word0");
            AddTexture("word1", "font/word1");
            AddTexture("word2", "font/word2");
            AddTexture("word3", "font/word3");
            AddTexture("word4", "font/word4");
            AddTexture("word5", "font/word5");
            AddTexture("word6", "font/word6");
            AddTexture("word7", "font/word7");
            AddTexture("word8", "font/word8");
            AddTexture("word9", "font/word9");
            AddTexture("dot", "font/dot");
            AddTexture("apostrof", "font/apostrof");
            AddTexture("tilda", "font/tilda");
            AddTexture("alert", "font/alert");
            AddTexture("mail", "font/mail");
            AddTexture("hashtag", "font/hashtag");
            AddTexture("dollar", "font/dollar");
            AddTexture("percent", "font/percent");
            AddTexture("crossup", "font/crossup");
            AddTexture("ampersant", "font/ampersant");
            AddTexture("star", "font/star");
            AddTexture("leftbrakket", "font/leftbrakket");
            AddTexture("rightbrakket", "font/rightbrakket");
            AddTexture("line", "font/line");
            AddTexture("equle", "font/equle");
            AddTexture("downline", "font/downline");
            AddTexture("plus", "font/plus");
            AddTexture("leftsqurebrakket", "font/leftsqurebrakket");
            AddTexture("rightsqurebrakket", "font/rightsqurebrakket");
            AddTexture("codebegin", "font/codebegin");
            AddTexture("codeend", "font/codeend");
            AddTexture("leftobliqueline", "font/leftobliqueline");
            AddTexture("dotcomma", "font/dotcomma");
            AddTexture("doubledot", "font/doubledot");
            AddTexture("doublequotes", "font/doublequotes");
            AddTexture("quotes", "font/quotes");
            AddTexture("leftcross", "font/leftcross");
            AddTexture("rightcross", "font/rightcross");
            AddTexture("rightobliqueline", "font/rightobliqueline");
            AddTexture("question", "font/question");
            AddTexture("comma", "font/comma");
            AddTexture("verticalline", "font/verticalline");
            

            
            // AddTexture("word1", "words/word1");
            // AddTexture("word2", "words/word2");
            // AddTexture("word3", "words/word3");
            // AddTexture("word4", "words/word4");
            // AddTexture("word5", "words/word5");
            // AddTexture("word6", "words/word6");
            // AddTexture("word7", "words/word7");
            // AddTexture("word8", "words/word8");
            // AddTexture("word9", "words/word9");

            // AddTexture("worda", "words/worda");
            // AddTexture("wordb", "words/wordb");
            // AddTexture("wordc", "words/wordc");
            // AddTexture("wordd", "words/wordd");
            // AddTexture("worde", "words/worde");
            // AddTexture("wordf", "words/wordf");
            // AddTexture("wordg", "words/wordg");
            // AddTexture("wordh", "words/wordh");
            // AddTexture("wordi", "words/wordi");
            // AddTexture("wordk", "words/wordk");
            // AddTexture("wordl", "words/wordl");
            // AddTexture("wordm", "words/wordm");
            // AddTexture("wordn", "words/wordn");
            // AddTexture("wordo", "words/wordo");
            // AddTexture("wordp", "words/wordp");
            // AddTexture("wordq", "words/wordq");
            // AddTexture("wordr", "words/wordr");
            // AddTexture("words", "words/words");
            // AddTexture("wordt", "words/wordt");
            // AddTexture("wordu", "words/wordu");
            // AddTexture("wordv", "words/wordv");
            // AddTexture("wordw", "words/wordw");
            // AddTexture("wordx", "words/wordx");
            // AddTexture("wordy", "words/wordy");
            // AddTexture("wordz", "words/wordz");
            // AddTexture("word ", "words/word ");

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