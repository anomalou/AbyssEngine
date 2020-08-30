using AbyssPlugins;

namespace AbyssBehavior{
    class PluginDescription:Window{

        protected override void Initialization(){
            SetLogic(new PluginDescriptionLogic(this));
            // logic = new PluginDescriptionLogic(this);

            TextBox name = new TextBox("");
            TextBox description = new TextBox("");
            
            name.SetPosition(new Vector(1,1));
            name.SetSize(new Vector(62, 1));
            description.SetPosition(new Vector(1,3));
            description.SetSize(new Vector(62, 31));

            AddWidget("name", name);
            AddWidget("description", description);
        }
    }
}