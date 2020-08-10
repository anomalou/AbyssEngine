using AbyssLibraries;

namespace AbyssBehavior{
    class PluginsListLogic:Logic{

        public PluginsListLogic(Window parent):base(parent){}

        public override void Initialization(){
            control.Add(KeysToAction.Actions.Deny, Exit);
            // for(int i = 0; i < PluginManager.plugins.Count; i++){
            //     menu.Add("plugin" + i, ShowDescription);
            // }
        }

        protected void ShowDescription(){
            
        }

        protected void Exit(){
            Core.CloseWindow(parent);
        }
    }
}