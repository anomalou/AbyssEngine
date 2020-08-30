namespace AbyssBehavior{
    class PluginsList:Window{
        protected override void Initialization(){
            SetLogic(new PluginsListLogic(this));
            // logic = new PluginsListLogic(this);

            TextBox window = new TextBox("Installed plugins:");
            window.SetPosition(new Vector(1,1));

            ScrollBox group = new ScrollBox();
            group.SetPosition(new Vector(1,3));
            group.SetSize(new Vector(62, 34));
            AddWidget("group", group);
            AddWidget("window",window);
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