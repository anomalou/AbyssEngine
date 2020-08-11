using AbyssLibraries;
using AbyssPlugins;

namespace AbyssBehavior{
    class PluginsListLogic:Logic{

        public PluginsListLogic(Window parent):base(parent){}

        public override void Initialization(){
            control.Add(KeysToAction.Actions.Deny, Exit);
            for(int i = 0; i < PluginManager.plugins.Count; i++){
                menu.Add("plugin"+i,ShowDescription);
            }
        }

        protected void ShowDescription(){
            int i = 0;
            foreach(string plugin in menu.Keys){
                if(currentMenu == plugin){
                    EmitSignal("pluginInfo", PluginManager.plugins[i]);
                    Core.OpenWindow(new PluginDescription(), window);
                    return;
                }
                i++;
            }
        }

        protected void Exit(){
            Core.CloseWindow(window);
        }
    }
}