using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {
        int dangeonW;   //dangeon height
        int dangeonH;   //dangeon width

        int playerX,playerY;    //player coordinate x         player coordinate y
        bool play;

        //int[,] fullMap;

        int[] wallList;

        Obj[,] MapObjs;

        Program(){
            dangeonH = 15;
            dangeonW = 15;
            playerX = 1;
            playerY = 1;
            play = true;
            //fullMap = new int[dangeonW,dangeonH];
            //fullMap[playerX,playerY] = 100;
            wallList = new int[11]{1,2,3,4,5,6,7,8,9,10,11}; //wall list update if need new impassable object
            MapObjs = new Obj[dangeonW,dangeonH];
            RefreshMap();
            CreateObj(playerX,playerY,100);
        }

        static void Main(string[] args)
        {   
            char key;
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program m = new Program();
            m.Maps(1);
            m.Render();
            while(m.play){
                key = Console.ReadKey().KeyChar;
                switch(key){
                    case 'w':
                        m.MovePlayer(m.playerX,m.playerY - 1);
                    break;
                    case 's':
                        m.MovePlayer(m.playerX,m.playerY + 1);
                    break;
                    case 'a':
                        m.MovePlayer(m.playerX - 1,m.playerY);
                    break;
                    case 'd':
                        m.MovePlayer(m.playerX + 1,m.playerY);
                    break;
                    case 'q':
                        m.play = false;
                    break;
                }
            }
        }
        

        void Render(){
            Console.Clear();
            for (int i = 0; i < dangeonH; i++)
            {
                for (int t = 0; t < dangeonW; t++)
                {
                    Console.Write(MapObjs[t,i].symbol);
                }
                Console.WriteLine();
            }
        }

        void Render(int x, int y){
            Console.SetCursorPosition(x,y);
            Console.Write(MapObjs[x,y].symbol);
            Console.SetCursorPosition(0,15);
            Console.Write(' ');
        }

        char GetSimbol(int ID){
            switch(ID){
                case 1:
                    return '\u2501';    //horizontal wall
                case 2:
                    return '\u2502';    //vertical wall
                case 3:
                    return '\u250f';    //left up angle
                case 4:
                    return '\u2513';    //right up angle
                case 5:
                    return '\u2517';    //left down angle
                case 6:
                    return '\u251b';    //right down angle
                case 7:
                    return '\u251d';    //left crossroad
                case 8:
                    return '\u2525';    //right crossroad
                case 9:
                    return '\u252f';    //up crossroad
                case 10:
                    return '\u253b';    //down crossroad
                case 11:
                    return '\u254b';    //cross
                case 12:
                    return '\u2509';    //horizontal door;
                case 13:
                    return '\u250b';    //vertical door;
                case 100:
                    return '@'; //player
                case 0:
                    return ' '; //empery cell
                default:
                    return ' ';
            }
        }

        void RemoveObj(int x, int y){
            MapObjs[x,y] = null;
            CreateObj(x,y,0);
        }

        void CreateObj(int x, int y, int ID){
            Obj u = new Obj();
            u.symbol = GetSimbol(ID);
            u.ID = ID;
            MapObjs[x,y] = u;
        }

        void CreateObj(int x, int y, string name, int ID){
            Obj u = new Obj();
            u.name = name;
            u.symbol = GetSimbol(ID);
            u.ID = ID;
            MapObjs[x,y] = u;
        }

        void CreateObj(int x, int y, string name, int ID, bool use, object behaviour){
            Obj u = new Obj();
            u.name = name;
            u.symbol = GetSimbol(ID);
            u.ID = ID;
            u.use = use;
            u.behaviour = behaviour;
            MapObjs[x,y] = u;
        }

        void RefreshMap(){
            for(int i = 0; i < dangeonH; i++){
                for(int t = 0; t < dangeonW; t++){
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
                //fullMap[(int)Math.Round(xr),(int)Math.Round(yr)] = ID;
                CreateObj((int)Math.Round(xr),(int)Math.Round(yr),ID);
                xr = xr + (x1-x)/L;
                yr = yr + (y1-y)/L;
            }
        }

        void DrawSimpleDot(int x, int y, int ID){
            //fullMap[x,y] = ID;
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
            for(int i = 0; i < wallList.Length; i++){
                if(wallList[i] == MapObjs[x,y].ID){
                    return true;
                }
            }
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
            }
        }
    }
}