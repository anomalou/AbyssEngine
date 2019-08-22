using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {
        int dungeonW;   //dangeon height
        int dungeonH;   //dangeon width

        int playerX,playerY;    //player coordinate x         player coordinate y
        bool play;

        ObjsList objsList;

        Obj[,] MapObjs;

        Program(){
            objsList = new ObjsList();
            dungeonH = 15;
            dungeonW = 15;
            playerX = 1;
            playerY = 1;
            play = true;
            MapObjs = new Obj[dungeonW,dungeonH];
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
            for (int i = 0; i < dungeonH; i++)
            {
                for (int t = 0; t < dungeonW; t++)
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

        void RemoveObj(int x, int y){
            CreateObj(x,y,0);
        }

        void CreateObj(int x, int y, int ID){
            MapObjs[x,y] = objsList.obj[ID];
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
            }else if(WallCheck(x,y) == true & UsableCheck(x,y) == true){
                MapObjs[x,y].behaviour.Action(x,y);
            }
        }
    }
}