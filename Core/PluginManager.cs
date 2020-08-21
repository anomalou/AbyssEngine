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
                    try{
                        pluginTypes = lib.GetTypes();
                    }catch(Exception ex){
                        Core.ThrowError(ex);
                    }
                    if(pluginTypes != null){
                        foreach(Type type in pluginTypes){
                            try{
                                if(typeof(IPlugin).IsAssignableFrom(type)){
                                    IPlugin pluginInfo = (IPlugin)Activator.CreateInstance(type);
                                    plugins.Add(pluginInfo);
                                }else if(typeof(IStat).IsAssignableFrom(type)){
                                    GameCore.statsList.Add((IStat)Activator.CreateInstance(type));
                                }else if(typeof(IGameRule).IsAssignableFrom(type)){
                                    GameCore.gameRulesList.Add((IGameRule)Activator.CreateInstance(type));
                                }else if(typeof(IGameObject).IsAssignableFrom(type)){
                                    GameCore.gameObjectsList.Add((IGameObject)Activator.CreateInstance(type));
                                }else if(typeof(IMap).IsAssignableFrom(type)){
                                    GameCore.mapsList.Add((IMap)Activator.CreateInstance(type));
                                }
                            }catch(Exception ex){
                                ex = new Exception("Error with load plugin content!");
                                ex.Source = lib.Location;
                                Core.ThrowError(ex);
                            }
                        }
                    }else
                        continue;
                }
            }
        }
    }
}