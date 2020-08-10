using AbyssLibraries;

namespace AbyssBehavior{
    class PluginsList:Window{
        protected override void Initialization(){
            logic = new PluginsListLogic(this);
            transform.SetupScale(Core.buffer.scale);
            SetupBackground(FillBackground());

            ScrollBox group = new ScrollBox();
            group.SetPosition(new Vector(1,1));
            group.SetSize(new Vector(ScreenBufferParam.width - 2, ScreenBufferParam.height - 2));
            AddWidget("group", group);
            if(PluginManager.plugins.Count > 0){
                for(int i = 0; i < PluginManager.plugins.Count; i++){
                    TextBox plugin = new TextBox(PluginManager.plugins[i].name);
                    group.AddItem(plugin);
                    AddMenu("plugin" + i, plugin);
                }
            }else{
                TextBox empty = new TextBox("no plugins");
                group.AddItem(empty);
                AddWidget("empty", empty);
            }
        }
    }
}