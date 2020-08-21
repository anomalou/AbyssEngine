using System.Collections.Generic;

namespace AbyssBehavior{
    public static class SwapBuffer{
        static Dictionary<string, object> buffer;
        public static void Initialization(){
            buffer = new Dictionary<string, object>();
        }

        public static void AddInfo(string name){
            if(!buffer.ContainsKey(name))
                buffer.Add(name, null);
        }

        public static void AddInfo(string name, object package){
            if(!buffer.ContainsKey(name))
                buffer.Add(name, package);
        }

        public static object GetInfo(string name){
            if(buffer.ContainsKey(name)){
                object info = buffer[name];
                buffer.Remove(name);
                return info;
            }else
                return null;
        }

        public static bool CheckInfo(string name){
            if(buffer.ContainsKey(name))
                return true;
            else
                return false;
        }
    }
}