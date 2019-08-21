using System;

namespace ConsoleApplication
{
    class Program
    {
        int dangeonW;
        int dangeonH;

        int[,] fullMap;

        Program(){
            dangeonH = 15;
            dangeonW = 15;
            fullMap = new int[dangeonW,dangeonH];
        }

        static void Main(string[] args)
        {
            Program m = new Program();
            m.fullMap[0,0] = 1;
            m.fullMap[0,14] = 1;
            m.fullMap[14,0] = 1;
            m.fullMap[14,14] = 1;
            m.DrawLine(0f,0f,5f,14f);
            m.Render();
            Console.ReadLine();
        }

        void Render(){
            Console.Clear();
            for (int i = 0; i < dangeonH; i++)
            {
                for (int t = 0; t < dangeonW; t++)
                {
                    if(fullMap[t,i] == 1)
                        Console.Write('#');
                    else
                        Console.Write('_');
                }
                Console.WriteLine();
            }
        }

        void DrawLine(float x, float y, float x1, float y1){
            float xr,yr;
            float L1,L2,L;
            L1 = Math.Abs(x1-x);
            L2 = Math.Abs(y1-y);
            //Console.WriteLine(L1+"    "+L2);
            if(L1>L2)
                L = L1 + 1;
            else
                L = L2 + 1;
            xr = x;
            yr = y;
            for(int i = 0; i < L;i++){
                //Console.WriteLine(xr+"  "+yr);
                fullMap[(int)Math.Round(xr),(int)Math.Round(yr)] = 1;
                //Console.WriteLine((x1-x)/L);
                xr = xr + (x1-x)/L;
                yr = yr + (y1-y)/L;
            }
        }
    }
}