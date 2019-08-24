using System;

namespace ConsoleApplication
{
    class Source
    {
        private int _windowSizeH{get;} = 60;
        private int _windowSizeW{get;} = 30;
        IWindow[] windowList;

        IWindow highlightedWindow;
        int dungeonH{get;set;}   //dangeon height
        int dungeonW{get;set;}   //dangeon width

        public int playerX,playerY;    //player coordinate x         player coordinate y
        bool play;

        ObjsList objsList;

        Obj[,] MapObjs{get;set;}

        Source source;

        static void Main(string[] args)
        {   
            Source s = new Source();
            s.source = s;
            char key;
            s.GameLaunch();
            Console.WriteLine(s.highlightedWindow.sizeX);
            while(s.play){
                s.UpdateWindow(s.highlightedWindow);
                key = Console.ReadKey().KeyChar;
                switch(key){
                    case 'w':
                        s.MovePlayer(s.playerX,s.playerY - 1);
                    break;
                    case 's':
                        s.MovePlayer(s.playerX,s.playerY + 1);
                    break;
                    case 'a':
                        s.MovePlayer(s.playerX - 1,s.playerY);
                    break;
                    case 'd':
                        s.MovePlayer(s.playerX + 1,s.playerY);
                    break;
                    case 'q':
                        s.play = false;
                    break;
                }
            }
        }

        void GameLaunch(){
            objsList = new ObjsList();
            windowList = new IWindow[1];
            dungeonH = 15;
            dungeonW = 15;
            playerX = 1;
            playerY = 1;
            play = true;
            MapObjs = new Obj[dungeonW,dungeonH];
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            source.RefreshMap();
            source.CreateObj(playerX,playerY,100);
            source.Maps(1);
            highlightedWindow = OpenWindow(20,0,new GameplayWindow());
            //Console.WriteLine("Done");
        }

        //canvas control

        public IWindow OpenWindow(int positionX,int positionY,IWindow window){
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] == null){
                    window.Fill(source);
                    RenderWindow(positionX,positionY,window);
                    return window;
                }
            }
            return null;
        }

        public void RenderWindow(int x,int y,IWindow w){
            int sizeX,sizeY;
            sizeX = w.sizeX;
            sizeY = w.sizeY;
            w.positionX = x;
            w.positionY = y;
            Console.SetCursorPosition(x,y);
            for(int i = 0; i < sizeX; i++){
                for(int t = 0; t < sizeY; t++){
                    Console.Write(w.content[t,i]);
                }
                Console.SetCursorPosition(x,y+i);
            }

        }

        public void UpdateWindow(IWindow w){
            w.Update(source);
            for(int i = 0; i < w.sizeX; i++){
                for(int t = 0; t < w.sizeY; t++){
                        Console.SetCursorPosition(t+w.positionX,i+w.positionY);
                        Console.Write(w.content[t,i]);
                }
            }
            Console.SetCursorPosition(0,16);
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


        //properties

        public int WindowSizeH{
            get{
                return _windowSizeH;
            }
        }

        public int WindowSizeW{
            get{
                return _windowSizeW;
            }
        }

        public int GetDungeonH{
            get{
                return dungeonH;
            }
        }

        public int GetDungeonW{
            get{
                return dungeonH;
            }
        }

        public Obj[,] GetMapObj{
            get{
                return MapObjs;
            }
        }

        //game map control

        public void RemoveObj(int x, int y){
            CreateObj(x,y,0);
        }

        public void CreateObj(int x, int y, int ID){
            MapObjs[x,y] = objsList.obj[ID];
            //Render(x,y);
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
            //Render(x,y);
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
                    DrawSimpleDot(3,4,12);
                break;
                default:

                break;
            }
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
                //Render(playerX,playerY);
                playerX = x;
                playerY = y;
                //Render(x,y);
            }else if(WallCheck(x,y) == true)
                    if(UsableCheck(x,y) == true)
                        MapObjs[x,y].behaviour.Action(x,y,source);
        }
    }
}