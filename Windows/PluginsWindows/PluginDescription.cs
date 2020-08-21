using AbyssPlugins;

namespace AbyssBehavior{
    class PluginDescription:Window{

        protected override void Initialization(){
            SetLogic(new PluginDescriptionLogic(this));
            // logic = new PluginDescriptionLogic(this);
            transform.SetScale(Core.buffer.scale);
            SetupBackground(FillBackground());

            TextBox name = new TextBox("");
            TextBox description = new TextBox("");
            
            name.SetPosition(new Vector(1,1));
            name.SetSize(new Vector(Core.buffer.width - 2, 1));
            description.SetPosition(new Vector(1,3));
            description.SetSize(new Vector(Core.buffer.width - 2, Core.buffer.height - 5));

            AddWidget("name", name);
            AddWidget("description", description);
        }
    }
}