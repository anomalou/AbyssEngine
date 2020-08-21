namespace AbyssBehavior{
    class ErrorWithPlugin:Window{
        protected override void Initialization(){
            SetLogic(new ErrorWithPluginLogic(this));
            // logic = new ErrorWithPluginLogic(this);
            transform.SetScale(Core.buffer.scale);
            SetupBackground(FillBackground());

            TextBox excep1 = new TextBox("WARNING!!! Detected error with some of yours plugins!");
            TextBox excep2 = new TextBox("Please check you plugins folder, on contact with plagin's developer.");
            excep2.SetSize(new Vector(ScreenBufferParam.width - 2, 2));
            TextBox excep3 = new TextBox("Maybe you should install one of this plugins?");
            TextBox excep4 = new TextBox("Text of error:");


            excep1.SetPosition(new Vector(1,1));
            excep2.SetPosition(new Vector(1,3));
            excep3.SetPosition(new Vector(1,5));
            excep4.SetPosition(new Vector(1,6));

            AddWidget("exc1", excep1);
            AddWidget("exc2", excep2);
            AddWidget("exc3", excep3);
            AddWidget("exc4", excep4);
        }
    }
}