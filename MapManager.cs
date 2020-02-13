using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace AbyssBehaviours{
    //[DataContract]
    class MapManager{

        //[DataMember]
        string[] map;

        public MapManager(){
            //DataContractJsonSerializer j = new DataContractJsonSerializer(typeof(FileManager));
            //MemoryStream s = new MemoryStream();
            //j.WriteObject(s,this);
            //s.Close();
        }

        public string[] GetMap(string name){
            switch(name){
                case "room":
                    map = new string[11]{"────────────────────",
                                         "|..............,...|",
                                         "|..................|",
                                         "|───#───────────#──|",
                                         "|.......,.|........|",
                                         "|.........|....,...|",
                                         "|.........#........|",
                                         "|──────────────#───|",
                                         "|..............,...|",
                                         "─────#──────────────",
                                         "|...........       |"};
                    return map;
                default:
                    return map;
            }
        }
    }
}