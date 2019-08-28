using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace ConsoleApplication{
    //[DataContract]
    class FileManager{

        //[DataMember]
        string[] map;

        public FileManager(){
            //DataContractJsonSerializer j = new DataContractJsonSerializer(typeof(FileManager));
            //MemoryStream s = new MemoryStream();
            DirectoryInfo d = new DirectoryInfo("maps");
            if(!d.Exists)
                d.Create();
            //j.WriteObject(s,this);
            //s.Close();
        }

        public string[] GetMap(string name){
            switch(name){
                case "room":
                    map = new string[11]{"────────────────────",
                                         "|..................|",
                                         "|..................|",
                                         "|───#───────────#──|",
                                         "|.........|........|",
                                         "|.........|........|",
                                         "|.........#........|",
                                         "|──────────────#───|",
                                         "|..................|",
                                         "─────#──────────────",
                                         "|...........       |"};
                    return map;
                default:
                    return map;
            }
        }
    }
}