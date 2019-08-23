using System;

namespace ConsoleApplication
{
    class Source
    {
        int dungeonH;   //dangeon height
        int dungeonW;   //dangeon width

        int playerX,playerY;    //player coordinate x         player coordinate y
        bool play;

        ObjsList objsList;

        Obj[,] MapObjs;

        public static Source source;

        public Source(bool start){
            if(start == true){
            objsList = new ObjsList();
            dungeonH = 15;
            dungeonW = 15;
            playerX = 1;
            playerY = 1;
            play = true;
            MapObjs = new Obj[dungeonW,dungeonH];
            }
        }
        public Source(){}

        static void Main(string[] args)
        {   
            Source _source = new Source(true);
            source = _source;
            char key;
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            source.RefreshMap();
            source.CreateObj(source.playerX,source.playerY,100);
            source.Maps(1);
            Console.WriteLine(source.MapObjs[1,1].name);
            while(source.play){
                key = Console.ReadKey().KeyChar;
                switch(key){
                    case 'w':
                        source.MovePlayer(source.playerX,source.playerY - 1);
                    break;
                    case 's':
                        source.MovePlayer(source.playerX,source.playerY + 1);
                    break;
                    case 'a':
                        source.MovePlayer(source.playerX - 1,source.playerY);
                    break;
                    case 'd':
                        source.MovePlayer(source.playerX + 1,source.playerY);
                    break;
                    case 'q':
                        source.play = false;
                    break;
                }
            }
        }

        public void Render(){
            Console.Clear();
            for (int i = 0; i < dungeonH; i++)
            {
                for (int t = 0; t < dungeonW; t++)
                {
                    Console.Write(MapObjs[t,i].symbol);
                }
                Console.WriteLine();
            }
        }

        public void Render(int x, int y){
            Console.SetCursorPosition(x,y);
            Console.Write(MapObjs[x,y].symbol);
            Console.SetCursorPosition(0,15);
            Console.Write(' ');
        }

        public void RemoveObj(int x, int y){
            CreateObj(x,y,0);
        }

        public void CreateObj(int x, int y, int ID){
            MapObjs[x,y] = objsList.obj[ID];
            Render(x,y);
        }

        void RefreshMap(){
            for(int i = 0; i < dungeonH; i++){
                for(int t = 0; t < dungeonW; t++){
                    if(MapObjs[i,t] == null){
                        CreateObj(i,t,0);
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
            Render(x,y);
        }

        void Maps(int i){
            switch (i)
            {
                case 1:
                    DrawSimpleLine(0,0,14,0,1);
                    DrawSimpleLine(0,0,0,14,2);
                    DrawSimpleLine(0,14,14,14,1);
                    DrawSimpleLine(14,0,14,14,2);
                    DrawSimpleLine(0,4,9,4,1);
                    DrawSimpleLine(10,4,14,4,1);
                    DrawSimpleDot(0,0,3);
                    DrawSimpleDot(14,0,4);
                    DrawSimpleDot(0,14,5);
                    DrawSimpleDot(14,14,6);
                    DrawSimpleDot(0,4,7);
                    DrawSimpleDot(14,4,8);
                    DrawSimpleDot(9,4,12);
                break;
                default:

                break;
            }
        }

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
                Render(playerX,playerY);
                playerX = x;
                playerY = y;
                Render(x,y);
            }else if(WallCheck(x,y) == true)
                    if(UsableCheck(x,y) == true)
                        MapObjs[x,y].behaviour.Action(x,y);
        }
    }
}