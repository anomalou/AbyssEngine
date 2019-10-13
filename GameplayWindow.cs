using System;

namespace ConsoleApplication{
    class GameplayWindow:IWindow{

        string _name;
        int _sizeX;
        int _sizeY;
        int _positionX;
        int _positionY;
        char[,,] _content;


        int dungeonH{get;set;}   //dangeon height
        int dungeonW{get;set;}   //dangeon width
        int playerX,playerY;    //player coordinate x         player coordinate y
        int playerHP;
        ObjsList objsList;
        Inventory[] inventory;
        Obj[,] MapObjs{get;set;}

        int mapX,mapY;
        int tx,ty;

        string[] text;

        public string name{
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }
        public int sizeX{
            get{
                return _sizeX;
            }
            set{
                _sizeX = value;
            }
        }

        public int sizeY{
            get{
                return _sizeY;
            }
            set{
                _sizeY = value;
            }
        }

        public int positionX{
            get{
                return _positionX;
            }
            set{
                _positionX = value;
            }
        }

        public int positionY{
            get{
                return _positionY;
            }
            set{
                _positionY = value;
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

        public GameplayWindow(){
            text = new string[2] { "Your player", "Inventroy" };
            name = "Map";
            sizeX = 40;
            sizeY = 15;
            content = new char[sizeX,sizeY,2];
            inventory = new Inventory[6];
            mapX = sizeX/2-2;
            mapY = sizeY - 4;
            dungeonH = 100;
            dungeonW = 100;
            MapObjs = new Obj[dungeonW,dungeonH];
            objsList = new ObjsList();
        }

        void CreateWindow(){
            string hp = "HP:" + playerHP.ToString();
            for(int i = 0; i < sizeX; i ++)
                for(int t = 0; t < sizeY; t++)
                    content[i,t,0] = '▓';
            for (int i = 0; i < name.Length; i++)
            {
                content[i + 1, 1, 0] = name[i];
                content[i + 1, 1, 1] = 'b';
            }
            for(int i = 0; i < 3 + playerHP.ToString().Length; i++){
                content[i+ mapX + 3, 4,0] = hp[i];
            }
            for(int i = 0; i < text[0].Length; i++)
            {
                content[i + mapX + 3, 1, 1] = 'G';
                content[i + mapX + 3, 1, 0] = text[0][i];
            }
            for(int i = 0; i < text[1].Length; i++)
            {
                content[mapX + i + 3, 6, 0] = text[1][i];
                content[mapX + i + 3, 6, 1] = 'G';
            }
            for(int i = 0; i < inventory.Length; i++)
            {
                for(int t = 0; t < sizeX/2 - 3; t++)
                {
                    content[mapX + 3 + t, i + 8, 0] = ' ';
                    content[mapX + 3 + t, i + 8, 1] = 'b';
                }
            }
        }
        /*public void Start(Source s){
            playerX = 1;
            playerY = 1;
            RefreshMap();
            CreateObj(playerX,playerY,'@');
            CreateWindow();
            Update();
        }*/

        public void Start(Source s, MapManager f){
            playerX = 1;
            playerY = 1;
            playerHP = 100;
            string[] map = f.GetMap("room");
            for(int i = 0; i < map.Length; i++)
                for(int t = 0; t < map[i].Length; t++)
                    CreateObj(t,i,map[i][t]);
            RefreshMap();
            CreateObj(playerX,playerY,'@');
            CreateWindow();
            Update();
        }

        public void Update(){
            for(int i = 0; i < mapX; i++){
                for(int t = 0; t < mapY; t++){
                    tx = playerX - mapX/2 + i;
                    ty = playerY - mapY/2 + t;
                    if(tx >= 0 & tx < dungeonW & ty >= 0 & ty < dungeonH){
                        content[i+1,t+3,0] = MapObjs[tx,ty].symbol;
                        content[i+1,t+3,1] = MapObjs[tx, ty].color;
                    }else{
                        content[i+1,t+3,0] = ' ';
                        content[i+1,t+3,1] = 'W';
                    }
                }
            }
            string hp = playerHP.ToString();
            for (int i = 0; i < 3; i++)
            {
                content[i + mapX + 6, 4, 1] = 'W';
                content[i + mapX + 6, 4,0] = '▓';
            }
            for (int i = 0; i < hp.Length; i++)
            {
                content[i + mapX + 6, 4, 1] = 'G';
                content[i + mapX + 6, 4,0] = hp[i];
            }
        }

        public void Control(char key){
            switch(key){
                case 'w':
                    MovePlayer(playerX,playerY - 1);
                break;
                case 's':
                    MovePlayer(playerX,playerY + 1);
                break;
                case 'a':
                    MovePlayer(playerX - 1,playerY);
                break;
                case 'd':
                    MovePlayer(playerX + 1,playerY);
                break;
                case 'q':
                    
                break;
            }
        }

        public void DegreeHp(int h)
        {
            playerHP = playerHP - h;
        }

        public void RemoveObj(int x, int y){
            CreateObj(x,y,'.');
        }

        public void CreateObj(int x, int y, char c){
            MapObjs[x,y] = objsList.Objs(c);
        }

        void RefreshMap(){
            for(int i = 0; i < dungeonH; i++){
                for(int t = 0; t < dungeonW; t++){
                    if(MapObjs[t,i] == null){
                        CreateObj(t,i,' ');
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

        bool WallCheck(int x, int y){
            if(MapObjs[x,y].impassible == true || MapObjs[x,y].symbol == ' ')
                return true;
            return false;
        }

        bool UsableCheck(int x, int y){
            if(x > -1 & x < dungeonW & y > -1 & y < dungeonH)
                if(MapObjs[x,y].use == true)
                    return true;
            return false;
        }

        void MovePlayer(int x,int y){
            if (WallCheck(x,y) == false){
                MapObjs[x, y].behaviour.Action(x, y, this);
                RemoveObj(playerX,playerY);
                CreateObj(x,y,'@');
                playerX = x;
                playerY = y;
            }else
                MapObjs[x, y].behaviour.Action(x, y, this);
        }
    }
    class Inventory
    {
        int count;
        string name;
    }
}