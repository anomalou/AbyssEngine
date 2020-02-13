using System;

namespace AbyssBehaviours{
    class GameplayWindow:IWindow{

        string _name;
        Vector _size;
        Vector _position;

        //Pixel[,] _content;
        public WindowContainer container{get;set;}


        Vector dungeon;
        Vector playerPosition;
        int playerHP;
        ObjsList objsList;
        public Source source;
        public Inventory inventory;
        Obj[,] MapObjs{get;set;}

        Vector mapSize;
        Vector tempPos;
        string[] text;

        public string name{
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }
        public Vector size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        public Vector position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public char code { get; set; }
        public int WID { get; set; }

        public GameplayWindow(){
            text = new string[2] { "Your player", "Inventroy" };
            name = "Game";
            code = '#';
            size = new Vector(40, 39);
            position = new Vector();
            //content = new Pixel[size.X(),size.Y()];  //1 layer is content, 2 layer is his color codes
            mapSize = new Vector(size.X() / 2 - 2, size.Y() - 4);
            dungeon = new Vector(100, 100);
            MapObjs = new Obj[dungeon.X(),dungeon.Y()];
            objsList = new ObjsList();
        }

        void CreateWindow(){
            int y = 0;
            string hp = "HP:" + playerHP.ToString();
            container = WindowBuilder.Build(size, name, code, WindowBuilder.State.Fill);
            for(int i = 0; i < 3 + playerHP.ToString().Length; i++){
                container.SetPixel(new Vector(i + mapSize.X() + 3, 4), new Pixel(hp[i],ConsoleColor.DarkGray));
            }
            for(int i = 0; i < text[0].Length; i++)
            {
                container.SetPixel(new Vector(i + mapSize.X() + 3, 1), new Pixel(text[0][i], ConsoleColor.DarkGray));
            }
            for(int i = 0; i < text[1].Length; i++)
            {
                container.SetPixel(new Vector(mapSize.X() + i + 3, 6), new Pixel(text[1][i], ConsoleColor.DarkGray));
            }
            for(int i = 0; i < inventory.SlotSize(); i++)
            {
                y++;
                /* for (int t = 0; t < size.X()/2 - 3; t++)
                {
                    if(inventory.item[i].name.Length > t)
                        container.SetPixel(new Vector(mapSize.X() + 3 + t, i + 8), new Pixel(inventory.item[i].name[t], ConsoleColor.Blue));
                    else
                        container.SetPixel(new Vector(mapSize.X() + 3 + t, i + 8), new Pixel(' ', ConsoleColor.Blue));
                } */
                container = WindowBuilder.PrintText(new Vector(mapSize.X() + 3, i + 8), container, 1, y.ToString(), ConsoleColor.DarkRed);
                container = WindowBuilder.PrintText(new Vector(mapSize.X() + 4, i + 8), container, 17, inventory.item[i].name, inventory.item[i].rarity);
            }
        }

        public void Start(Source s, MapManager f){
            source = s;
            inventory = new Inventory(source);
            playerPosition = new Vector(1, 1);
            playerHP = 100;
            string[] map = f.GetMap("room");
            for(int i = 0; i < map.Length; i++)
                for(int t = 0; t < map[i].Length; t++)
                    CreateObj(new Vector(t,i),map[i][t]);
            RefreshMap();
            CreateObj(playerPosition,'@');
            CreateWindow();
            Update();
        }

        public void Update(){
            for(int i = 0; i < mapSize.X(); i++){
                for(int t = 0; t < mapSize.Y(); t++){
                    tempPos = new Vector(playerPosition.X() - mapSize.X() / 2 + i, playerPosition.Y() - mapSize.Y() / 2 + t);
                    if(tempPos.X() > -1 & tempPos.X() < dungeon.X() & tempPos.Y() >-1 & tempPos.Y() < dungeon.Y()){
                        container.SetPixel(new Vector(i + 1,t + 3), new Pixel(MapObjs[tempPos.X(), tempPos.Y()].symbol, MapObjs[tempPos.X(), tempPos.Y()].color));
                    }else{
                        container.SetPixel(new Vector(i + 1,t + 3), new Pixel(' ', ConsoleColor.White));
                    }
                }
            }
            string hp = playerHP.ToString();
            for (int i = 0; i < 3; i++)
            {
                container.SetPixel(new Vector(i + mapSize.X() + 6, 4), new Pixel('▓', ConsoleColor.White));
            }
            for (int i = 0; i < hp.Length; i++)
            {
                container.SetPixel(new Vector(i + mapSize.X() + 6, 4), new Pixel(hp[i], ConsoleColor.DarkGray));
            }
            for (int i = 0; i < inventory.SlotSize(); i++)
            {
                /* for (int t = 0; t < size.X() / 2 - 3; t++)
                {
                    if (t < inventory.item[i].name.Length)
                        container.SetPixel(new Vector(mapSize.X() + 3 + t, i + 8), new Pixel(inventory.item[i].name[t], ConsoleColor.Blue));
                    else
                        container.SetPixel(new Vector(mapSize.X() + 3 + t, i + 8), new Pixel(' ', ConsoleColor.Blue));
                } */
                
                container = WindowBuilder.PrintText(new Vector(mapSize.X() + 4, i + 8), container, size.X() / 2 - 3, inventory.item[i].name, inventory.item[i].rarity);
            }
        }

        public void Control(ConsoleKeyInfo key){
            switch(key.Key){
                case ConsoleKey.W:
                    MovePlayer(new Vector(playerPosition.X(),playerPosition.Y() - 1));
                break;
                case ConsoleKey.S:
                    MovePlayer(new Vector(playerPosition.X(), playerPosition.Y() + 1));
                break;
                case ConsoleKey.A:
                    MovePlayer(new Vector(playerPosition.X() - 1, playerPosition.Y()));
                break;
                case ConsoleKey.D:
                    MovePlayer(new Vector(playerPosition.X() + 1, playerPosition.Y()));
                break;
                case ConsoleKey.D1:
                    inventory.RemoveItem(0);
                break;
                case ConsoleKey.D2:
                    inventory.RemoveItem(1);
                break;
                case ConsoleKey.D3:
                    inventory.RemoveItem(2);
                break;
                case ConsoleKey.D4:
                    inventory.RemoveItem(3);
                break;
                case ConsoleKey.D5:
                    inventory.RemoveItem(4);
                break;
                case ConsoleKey.D6:
                    inventory.RemoveItem(5);
                break;
                case ConsoleKey.C:
                    source.OpenWindow(position, new Commander());
                break;
                case ConsoleKey.Escape:
                    source.OpenWindow(new Vector(position.X() + 2, position.Y() + 2), new Executor());
                break;
            }
        }

        public void DegreeHp(int h)
        {
            playerHP = playerHP - h;
        }

        public void RemoveObj(Vector vector){
            CreateObj(vector,'.');
        }

        public void CreateObj(Vector vector, char c){
            if(vector.X() > -1 && vector.X() < dungeon.X() && vector.Y() > -1 && vector.Y() < dungeon.Y())
                MapObjs[vector.X(),vector.Y()] = objsList.Objs(c);
        }

        void RefreshMap()
        {
            for (int i = 0; i < dungeon.Y(); i++)
            {
                for (int t = 0; t < dungeon.X(); t++)
                {
                    if (MapObjs[t, i] == null)
                    {
                        CreateObj(new Vector(t, i), ' ');
                    }
                }
            }
        }


        //player movement

        bool WallCheck(Vector vector){
            if (MapObjs[vector.X(), vector.Y()].impassible == true || MapObjs[vector.X(), vector.Y()].symbol == ' ')
                return true;
            return false;
        }

        public void MovePlayer(Vector vector){
            if (vector.X() > -1 && vector.X() < dungeon.X() && vector.Y() > -1 && vector.Y() < dungeon.Y())
            {
                if (WallCheck(vector) == false)
                {
                    MapObjs[vector.X(), vector.Y()].behaviour.Action(vector, this);
                    RemoveObj(playerPosition);
                    CreateObj(vector, '@');
                    playerPosition = vector;
                }
                else
                    MapObjs[vector.X(), vector.Y()].behaviour.Action(vector, this);
            }
        }

        public void Start(Source s)
        {
            
        }

        public int ReturnValue(string name)
        {
            switch (name)
            {
                case "dungH":
                    return dungeon.X();
                case "dungW":
                    return dungeon.Y();
                default:
                    return -1;
            }
        }
    }
    class Inventory
    {
        public Item[] item;
        Items items;

        Source source;
        public Inventory(Source s)
        {
            s.AddDebug("Inventory iteration");
            source = s;
            items = new Items();
            item = new Item[6];
            for(int i = 0; i < item.Length; i++)
            {
                item[i] = items.GetItem(0);
            }
        }

        public int SlotSize()
        {
            return item.Length;
        }

        int CheckFree(){
            for(int i = 0; i < item.Length; i++){
                if(item[i].count == 0){
                    return i;
                }else
                    continue;
            }
            return -1;
        }

        public void SetItem(int ID)
        {
            int t = CheckFree();
            if(t != -1){
                item[t] = items.GetItem(ID);
            }
        }

        public void RemoveItem(int pos){
            item[pos] = items.GetItem(0);
        }

        public void SelectItem(){
            
        }
    }
}