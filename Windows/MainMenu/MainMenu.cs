namespace AbyssBehavior{
    class MainMenu: Window{
        protected override void Initialization(){
            SetLogic(new MenuLogic(this));
            TextBox title = new TextBox("Main menu");
            title.SetPosition(new Vector(10,10));
            title.SetSize(new Vector(62, 1));
            ImageView icon = new ImageView("player");
            icon.SetPosition(new Vector(200,10));
            ScrollBox menuList = new ScrollBox();
            menuList.SetPosition(new Vector(10,50));
            menuList.SetSpacing(1);
            menuList.SetSize(new Vector(20, 30));

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

        }
    }
}