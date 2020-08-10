using System.IO;
using System.Collections.Generic;
using System;
using System.Reflection;
using AbyssPlugins;

namespace AbyssBehavior{
    static class PluginManager{
        public static string pluginsPath = ".";
        public static List<IPlugin> plugins;
        public static void PrepareSpace(){
            DirectoryInfo dirInfo = new DirectoryInfo(pluginsPath + @"\plugins");
            if(!dirInfo.Exists){
                dirInfo.Create();
            }
        }

        public static void LoadPlugins(){
            string[] pluginsPaths = Directory.GetFiles(pluginsPath + @"\plugins", "*.dll");
            plugins = new List<IPlugin>();

            foreach(string path in pluginsPaths){
                Type[] pluginTypes = null;
                Assembly lib = Assembly.LoadFrom(path);
                if(lib == null)
                    continue;
                else{
                    pluginTypes = lib.GetTypes();
                    if(pluginTypes != null){
                        foreach(Type type in pluginTypes){
                            if(typeof(IPlugin).IsAssignableFrom(type)){
                                IPlugin pluginInfo = (IPlugin)Activator.CreateInstance(type);
                                plugins.Add(pluginInfo);
                            }else if(typeof(IStat).IsAssignableFrom(type)){
                                IStat stat = (IStat)Activator.CreateInstance(type);
                                stat.control = GameCore.statControl;
                                GameCore.stats.Add(stat);
                            }else if(typeof(IGameRule).IsAssignableFrom(type)){
                                IGameRule gameRule = (IGameRule)Activator.CreateInstance(type);
                                gameRule.control = GameCore.gameRuleControl;
                                GameCore.gameRules.Add(gameRule);
                            }
                        }
                    }else
                        continue;
                }
            }
        }
    }
}