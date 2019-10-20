using System;

namespace ConsoleApplication{
    class GameplayWindow:IWindow{

        string _name;
        Vector _size;
        Vector _position;

        char[,,] _content;


        Vector dungeon;
        //int dungeonH{get;set;}   //dangeon height
        //int dungeonW{get;set;}   //dangeon width
        Vector playerPosition;
        //int playerX,playerY;    //player coordinate x         player coordinate y
        int playerHP;
        ObjsList objsList;
        Source source;
        public Inventory inventory;
        Obj[,] MapObjs{get;set;}

        //int mapX,mapY;
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

        public char[,,] content{
            get{
                return _content;
            }
            set{
                _content = value;
            }
        }

        public char code { get; set; }

        public GameplayWindow(){
            text = new string[2] { "Your player", "Inventroy" };
            name = "Game";
            code = '#';
            size = new Vector(40, 15);
            position = new Vector();
            content = new char[size.X(),size.Y(),2];  //1 layer is content, 2 layer is his color codes
            inventory = new Inventory();
            mapSize = new Vector(size.X() / 2 - 2, size.Y() - 4);
            /*mapX = sizeX/2-2;
            mapY = sizeY - 4;*/
            dungeon = new Vector(100, 100);
            /*dungeonH = 100;
            dungeonW = 100;*/
            MapObjs = new Obj[dungeon.X(),dungeon.Y()];
            objsList = new ObjsList();
        }

        void CreateWindow(){
            string hp = "HP:" + playerHP.ToString();
            content = WindowBuilder.Build(size, name, code);
            /*for(int i = 0; i < sizeX; i ++)
                for(int t = 0; t < sizeY; t++)
                    content[i,t,0] = '▓';*/
            /*content[0, 0, 0] = '#';
            content[0, 0, 1] = 'Q';*/
            /*for (int i = 1; i < sizeX; i++)
            {
                content[i, 0, 0] = '=';
                content[i, 0, 1] = 'Q';
            }*/
            /*for (int i = 0; i < name.Length; i++)
            {
                content[i + 1, 1, 0] = name[i];
                content[i + 1, 1, 1] = 'b';
            }*/
            for(int i = 0; i < 3 + playerHP.ToString().Length; i++){
                content[i+ mapSize.X() + 3, 4,0] = hp[i];
            }
            for(int i = 0; i < text[0].Length; i++)
            {
                content[i + mapSize.X() + 3, 1, 1] = 'G';
                content[i + mapSize.X() + 3, 1, 0] = text[0][i];
            }
            for(int i = 0; i < text[1].Length; i++)
            {
                content[mapSize.X() + i + 3, 6, 0] = text[1][i];
                content[mapSize.X() + i + 3, 6, 1] = 'G';
            }
            for(int i = 0; i < inventory.SlotSize(); i++)
            {
                for (int t = 0; t < size.X()/2 - 3; t++)
                {
                    if(inventory.item[i].name.Length > t)
                        content[mapSize.X() + 3 + t, i + 8, 0] = inventory.item[i].name[t];
                    else
                        content[mapSize.X() + 3 + t, i + 8, 0] = ' ';
                    content[mapSize.X() + 3 + t, i + 8, 1] = 'b';
                }
                
            }
        }

        public void Start(Source s, MapManager f){
            source = s;
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
                        content[i+1,t+3,0] = MapObjs[tempPos.X(), tempPos.Y()].symbol;
                        content[i+1,t+3,1] = MapObjs[tempPos.X(), tempPos.Y()].color;
                    }else{
                        content[i+1,t+3,0] = ' ';
                        content[i+1,t+3,1] = 'W';
                    }
                }
            }
            string hp = playerHP.ToString();
            for (int i = 0; i < 3; i++)
            {
                content[i + mapSize.X() + 6, 4, 1] = 'W';
                content[i + mapSize.X() + 6, 4,0] = '▓';
            }
            for (int i = 0; i < hp.Length; i++)
            {
                content[i + mapSize.X() + 6, 4, 1] = 'G';
                content[i + mapSize.X() + 6, 4,0] = hp[i];
            }
            for (int i = 0; i < inventory.SlotSize(); i++)
            {
                for (int t = 0; t < size.X() / 2 - 3; t++)
                {
                    if (t < inventory.item[i].name.Length)
                        content[mapSize.X() + 3 + t, i + 8, 0] = inventory.item[i].name[t];
                    else
                        content[mapSize.X() + 3 + t, i + 8, 0] = ' ';
                    content[mapSize.X() + 3 + t, i + 8, 1] = 'b';
                }
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
                case ConsoleKey.C:
                    source.SetActive(source.OpenWindow(position, new Commander()));
                break;
                case ConsoleKey.Escape:
                    source.SetActive(source.OpenWindow(new Vector(position.X() + 2, position.Y() + 2), new Executor()));
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

        void RefreshMap(){
            for(int i = 0; i < dungeon.Y(); i++){
                for(int t = 0; t < dungeon.X(); t++){
                    if(MapObjs[t,i] == null){
                        CreateObj(new Vector(t, i),' ');
                    }
                }
            }
        }

        /*void DrawSimpleLine(float x, float y, float x1, float y1, char c){
            float xr,yr;
            float L1,L2,L;
            L1 = Math.Abs(x1-x);
            L2 = Math.Abs(y1-y);
            if(L1>L2)
                L = L1 + 1;
            else
                L = L2 + 1;
            xr = x;
            yr = y;
            for(int i = 0; i < L;i++){
                CreateObj((int)Math.Round(xr),(int)Math.Round(yr),c);
                xr = xr + (x1-x)/L;
                yr = yr + (y1-y)/L;
            }
        }

        void DrawSimpleDot(int x, int y, char c){
            CreateObj(x,y,c);
        }*/


        //player movement

        bool WallCheck(Vector vector){
            if (MapObjs[vector.X(), vector.Y()].impassible == true || MapObjs[vector.X(), vector.Y()].symbol == ' ')
                return true;
            return false;
        }

        /*bool UsableCheck(int x, int y){
            if(x > -1 & x < dungeonW & y > -1 & y < dungeonH)
                if(MapObjs[x,y].use == true)
                    return true;
            return false;
        }*/

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
        public Inventory()
        {
            items = new Items();
            item = new Item[6];
            for(int i = 0; i < item.Length; i++)
            {
                Item item = items.GetItem(-1);
                this.item[i] = item;
            }
        }

        public int SlotSize()
        {
            return item.Length;
        }

        public void SetItem(int ID)
        {
            Console.WriteLine("Setitem");
            for (int i = 0; i < SlotSize(); i++)
            {
                if(item[i].name == " ")
                {
                    item[i] = items.GetItem(ID);
                    break;
                }
            }
        }
    }
}