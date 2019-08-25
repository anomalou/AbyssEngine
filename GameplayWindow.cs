using System;

namespace ConsoleApplication{
    class GameplayWindow:IWindow{

        string _name;
        int _sizeX;
        int _sizeY;
        int _positionX;
        int _positionY;
        char[,] _content;


        int dungeonH{get;set;}   //dangeon height
        int dungeonW{get;set;}   //dangeon width
        public int playerX,playerY;    //player coordinate x         player coordinate y
        bool play;
        ObjsList objsList;
        Obj[,] MapObjs{get;set;}

        int mapX,mapY;
        int tx,ty;

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

        public char[,] content{
            get{
                return _content;
            }
            set{
                _content = value;
            }
        }

        public GameplayWindow(){
            name = "Gameplay";
            sizeX = 50;
            sizeY = 30;
            content = new char[sizeX,sizeY];
            mapX = sizeX/2-2;
            mapY = sizeY - 4;
            dungeonH = 100;
            dungeonW = 100;
            MapObjs = new Obj[dungeonW,dungeonH];
            objsList = new ObjsList();
        }
        public void Start(Source s){
            playerX = 1;
            playerY = 1;
            RefreshMap();
            CreateObj(playerX,playerY,100);
            Maps(1);
            for(int i = 0; i < sizeX; i ++)
                for(int t = 0; t < sizeY; t++)
                    content[i,t] = '#';
            for(int i = 0; i < name.Length; i++)
                content[i+1,1] = name[i];
            for(int i = 0; i < mapX; i++){
                for(int t = 0; t < mapY; t++){
                    tx = playerX - mapX/2 + i;
                    ty = playerY - mapY/2 + t;
                    if(tx >= 0 & tx < dungeonW & ty >= 0 & ty < dungeonH)
                        content[i+1,t+3] = MapObjs[tx,ty].symbol;
                    else
                        content[i+1,t+3] = ' ';
                }
            }
        }

        public void Update(){
            for(int i = 0; i < mapX; i++){
                for(int t = 0; t < mapY; t++){
                    tx = playerX - mapX/2 + i;
                    ty = playerY - mapY/2 + t;
                    if(tx >= 0 & tx < dungeonW & ty >= 0 & ty < dungeonH){
                        content[i+1,t+3] = MapObjs[tx,ty].symbol;
                    }else{
                        content[i+1,t+3] = ' ';
                    }
                }
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

        public void RemoveObj(int x, int y){
            CreateObj(x,y,0);
        }

        public void CreateObj(int x, int y, int ID){
            MapObjs[x,y] = objsList.obj[ID];
        }

        void RefreshMap(){
            for(int i = 0; i < dungeonH; i++){
                for(int t = 0; t < dungeonW; t++){
                    if(MapObjs[t,i] == null){
                        CreateObj(t,i,0);
                    }
                }
            }
        }

        void DrawSimpleLine(float x, float y, float x1, float y1, int ID){
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
                CreateObj((int)Math.Round(xr),(int)Math.Round(yr),ID);
                xr = xr + (x1-x)/L;
                yr = yr + (y1-y)/L;
            }
        }

        void DrawSimpleDot(int x, int y, int ID){
            CreateObj(x,y,ID);
        }


        //player movement

        bool WallCheck(int x, int y){
            if(MapObjs[x,y].impassible == true)
                return true;
            return false;
        }

        bool UsableCheck(int x, int y){
            if(MapObjs[x,y].use == true)
                return true;
            return false;
        }

        void MovePlayer(int x,int y){
            if(WallCheck(x,y) == false){
                RemoveObj(playerX,playerY);
                CreateObj(x,y,100);
                playerX = x;
                playerY = y;
            }else if(WallCheck(x,y) == true)
                    if(UsableCheck(x,y) == true)
                        MapObjs[x,y].behaviour.Action(x,y,this);
        }

        void Maps(int i){
            switch (i)
            {
                case 1:
                    DrawSimpleLine(0,0,99,0,1);
                    DrawSimpleLine(0,0,0,99,2);
                    DrawSimpleLine(0,99,99,99,1);
                    DrawSimpleLine(99,0,99,99,2);
                    DrawSimpleLine(0,4,9,4,1);
                    DrawSimpleLine(10,4,50,4,1);
                    DrawSimpleLine(20,4,20,30,2);
                    DrawSimpleDot(20,10,13);
                    DrawSimpleDot(0,0,3);
                    DrawSimpleDot(14,0,4);
                    DrawSimpleDot(0,14,5);
                    DrawSimpleDot(14,14,6);
                    DrawSimpleDot(0,4,7);
                    DrawSimpleDot(14,4,8);
                    DrawSimpleDot(9,4,12);
                    DrawSimpleDot(3,4,12);
                break;
                default:

                break;
            }
        }
    }
}