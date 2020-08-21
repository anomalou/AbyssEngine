using System.Collections.Generic;

namespace AbyssBehavior{
    public class Font{
        string characters = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.`~!@#$%^&*()-=_+[]{}\\;:\"\'<>/?,|";
        List<string> textures;

        RGBA _color;

        public RGBA color{get{return _color;}}

        Dictionary<char, string> font;
        public Font(){
            font = new Dictionary<char, string>();
            textures = new List<string>(){"null",
                                          "wordA_",
                                          "wordB_",
                                          "wordC_",
                                          "wordD_",
                                          "wordE_",
                                          "wordF_",
                                          "wordG_",
                                          "wordH_",
                                          "wordI_",
                                          "wordJ_",
                                          "wordK_",
                                          "wordL_",
                                          "wordM_",
                                          "wordN_",
                                          "wordO_",
                                          "wordP_",
                                          "wordQ_",
                                          "wordR_",
                                          "wordS_",
                                          "wordT_",
                                          "wordU_",
                                          "wordV_",
                                          "wordW_",
                                          "wordX_",
                                          "wordY_",
                                          "wordZ_",
                                          "wordA",
                                          "wordB",
                                          "wordC",
                                          "wordD",
                                          "wordE",
                                          "wordF",
                                          "wordG",
                                          "wordH",
                                          "wordI",
                                          "wordJ",
                                          "wordK",
                                          "wordL",
                                          "wordM",
                                          "wordN",
                                          "wordO",
                                          "wordP",
                                          "wordQ",
                                          "wordR",
                                          "wordS",
                                          "wordT",
                                          "wordU",
                                          "wordV",
                                          "wordW",
                                          "wordX",
                                          "wordY",
                                          "wordZ",
                                          "word0",
                                          "word1",
                                          "word2",
                                          "word3",
                                          "word4",
                                          "word5",
                                          "word6",
                                          "word7",
                                          "word8",
                                          "word9",
                                          "dot",
                                          "apostrof",
                                          "tilda",
                                          "alert",
                                          "mail",
                                          "hashtag",
                                          "dollar",
                                          "percent",
                                          "crossup",
                                          "ampersant",
                                          "star",
                                          "leftbrakket",
                                          "rightbrakket",
                                          "line",
                                          "equle",
                                          "downline",
                                          "plus",
                                          "leftsqurebrakket",
                                          "rightsqurebrakket",
                                          "codebegin",
                                          "codeend",
                                          "leftobliqueline",
                                          "dotcomma",
                                          "doubledot",
                                          "doublequotes",
                                          "quotes",
                                          "leftcross",
                                          "rightcross",
                                          "rightobliqueline",
                                          "question",
                                          "comma",
                                          "verticalline"};
            int i = 0;
            foreach(char key in characters){
                font.Add(key, textures[i]);
                i++;
            }

            _color = new RGBA(255, 255, 255, 255);
        }

        public string GetTexture(char character){
            if(font.ContainsKey(character))
                return font[character];
            else
                return font['?'];
        }
    }
}