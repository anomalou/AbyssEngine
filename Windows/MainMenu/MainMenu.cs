namespace AbyssBehavior{
    class MainMenu: Window{
        protected override void Initialization(){
            transform.SetScale(Core.buffer.scale);
            SetLogic(new MenuLogic(this));
            TextBox title = new TextBox("Main menu");
            title.SetPosition(new Vector(1,1));
            title.SetSize(new Vector(Core.buffer.scale.x - 2, 1));
            Image icon = new Image("player");
            icon.SetPosition(new Vector(11,1));
            ScrollBox menuList = new ScrollBox();
            menuList.SetPosition(new Vector(1,4));
            menuList.SetSpacing(1);
            menuList.SetSize(new Vector(10, 12));

            AddWidget("menu", menuList);
            TextBox start = new TextBox("Start");
            TextBox plugins = new TextBox("Plugins ...");
            
            
            TextBox exit = new TextBox("Exit");
            
            AddWidget("title", title);
            AddWidget("icon", icon);
            AddMenu("start", start);
            AddMenu("plugins", plugins);
            AddMenu("exit", exit);
            menuList.AddItem(start);
            menuList.AddItem(plugins);
            menuList.AddItem(exit);

            SetupBackground(FillBackground());
        }
    }
}