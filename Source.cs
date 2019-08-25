using System;

namespace ConsoleApplication
{
    class Source
    {
        private int _windowSizeH{get;} = 60;
        private int _windowSizeW{get;} = 30;
        IWindow[] windowList;
        int activeWindow;

        Source source;

        static void Main(string[] args)
        {   
            Source s = new Source();
            s.source = s;
            char key;
            s.GameLaunch();
            while(true){
                key = Console.ReadKey().KeyChar;
                s.windowList[s.activeWindow].Control(key);
                if(s.activeWindow != -1)
                    s.UpdateWindow(s.windowList[s.activeWindow]);
            }
        }

        void GameLaunch(){
            windowList = new IWindow[1];//how many windows have game
            //play = true;
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.SetBufferSize(200,200);
            //Console.SetWindowSize(100,200);
            activeWindow = OpenWindow(20,20,new GameplayWindow());//set gameplay window as active window
        }

        //canvas control

        public int OpenWindow(int positionX,int positionY,IWindow window){
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] == null){
                    window.Start(source);
                    RenderWindow(positionX,positionY,window);
                    windowList[i] = window;
                    return i;
                }
            }
            return -1;
        }

        public void RenderWindow(int x,int y,IWindow w){
            int sizeX,sizeY;
            sizeX = w.sizeX;
            sizeY = w.sizeY;
            w.positionX = x;
            w.positionY = y;
            Console.SetCursorPosition(x,y);
            for(int i = 0; i < sizeY; i++){
                for(int t = 0; t < sizeX; t++){
                    Console.Write(w.content[t,i]);
                }
                Console.SetCursorPosition(x,y+i);
            }
        }

        public void UpdateWindow(IWindow w){
            w.Update();
            for(int i = 0; i < w.sizeY; i++){
                for(int t = 0; t < w.sizeX; t++){
                        Console.SetCursorPosition(t+w.positionX,i+w.positionY);
                        Console.Write(w.content[t,i]);
                }
            }
            Console.SetCursorPosition(0,16);
        }

        public void CloseWindow(int windowNumber){
            windowList[windowNumber] = null;
            activeWindow = -1;
            ScreenUpdate();
        }

        public void ScreenUpdate(){
            Console.Clear();
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] != null)
                    RenderWindow(windowList[i].positionX,windowList[i].positionY,windowList[i]);
            }
        }

        /*public void Render(int x, int y){
            Console.SetCursorPosition(x,y);
            Console.Write(MapObjs[x,y].symbol);
            Console.SetCursorPosition(0,15);
            Console.Write(' ');
        }*/


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

        /*public int GetDungeonH{
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
        }*/

        //game map control
    }
}