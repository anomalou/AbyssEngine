using System;

namespace ConsoleApplication
{
    class Program
    {
        int dangeonW;
        int dangeonH;

        int playerX,playerY;
        bool play;

        int[,] fullMap;

        Program(){
            dangeonH = 15;
            dangeonW = 15;
            playerX = 1;
            playerY = 1;
            play = true;
            fullMap = new int[dangeonW,dangeonH];
            fullMap[playerX,playerY] = 2;
        }

        static void Main(string[] args)
        {   
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Program m = new Program();
            m.Maps(1);
            m.Render();
            while(m.play){
                if(Console.ReadKey().Key == ConsoleKey.UpArrow)
                    m.MovePlayer(m.playerX,m.playerY - 1);
                else if(Console.ReadKey().Key == ConsoleKey.DownArrow)
                    m.MovePlayer(m.playerX,m.playerY + 1);
                else if(Console.ReadKey().Key == ConsoleKey.LeftArrow)
                    m.MovePlayer(m.playerX - 1,m.playerY);
                else if(Console.ReadKey().Key == ConsoleKey.RightArrow)
                    m.MovePlayer(m.playerX + 1,m.playerY);
                else if(Console.ReadKey().Key == ConsoleKey.Escape)
                    m.play = false;
                m.Render();
            }
        }

        void Render(){
            Console.Clear();
            for (int i = 0; i < dangeonH; i++)
            {
                for (int t = 0; t < dangeonW; t++)
                {
                    if(fullMap[t,i] == 1)
                        Console.Write('#');
                    else if(fullMap[t,i] == 2)
                        Console.Write('@');
                    else   
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        void DrawLine(float x, float y, float x1, float y1){
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
                fullMap[(int)Math.Round(xr),(int)Math.Round(yr)] = 1;
                xr = xr + (x1-x)/L;
                yr = yr + (y1-y)/L;
            }
        }

        void Maps(int i){
            switch (i)
            {
                case 1:
                    DrawLine(0,0,14,0);
                    DrawLine(0,0,0,14);
                    DrawLine(0,14,14,14);
                    DrawLine(14,0,14,14);
                break;
                default:

                break;
            }
        }

        void MovePlayer(int x,int y){
            if(fullMap[x,y] == 0){
                fullMap[playerX,playerY] = 0;
                fullMap[x,y] = 2;
                playerX = x;
                playerY = y;
            }
        }
    }
}