using AbyssLibraries;

namespace AbyssBehavior{
    class ErrorWithPlugin:Window{
        protected override void Initialization(){
            SetLogic(new ErrorWithPluginLogic(this));
            // logic = new ErrorWithPluginLogic(this);
            transform.SetScale(Core.buffer.scale);
            SetupBackground(FillBackground());

            TextBox excep1 = new TextBox("detected error with some plugins");
            TextBox excep2 = new TextBox("you need to check plugins folder");

            excep1.SetPosition(new Vector(1,1));
            excep2.SetPosition(new Vector(1,3));

            AddWidget("exc1", excep1);
            AddWidget("exc2", excep2);
        }
    }
}