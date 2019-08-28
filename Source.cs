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
                if(s.activeWindow != -1)
                    s.UpdateWindow(s.windowList[s.activeWindow]);
                key = Console.ReadKey().KeyChar;
                s.windowList[s.activeWindow].Control(key);
            }
        }

        void GameLaunch(){
            windowList = new IWindow[1];//how many windows have game
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            activeWindow = OpenWindow(0,0,new GameplayWindow(), new FileManager());//set gameplay window as active window
        }

        //canvas control

        public int OpenWindow(int positionX,int positionY,IWindow window){
            int i = CheckFreeSpace();
            if(i != -1){
                window.Start(source);
                RenderWindow(positionX,positionY,window);
                windowList[i] = window;
                return i;
            }
            return -1;
        }

        public int OpenWindow(int positionX, int positionY, IWindow w, FileManager f){
            int i = CheckFreeSpace();
            if(i != -1){
                w.Start(source,f);
                RenderWindow(positionX,positionY, w);
                windowList[i] = w;
                return i;
            }
            return -1;
        }

        public void RenderWindow(int x,int y,IWindow w){
            int sizeX,sizeY;
            sizeX = w.sizeX;
            sizeY = w.sizeY;
            w.positionX = x;
            w.positionY = y;
            UpdateWindow(w);
        }

        public void UpdateWindow(IWindow w){
            w.Update();
            Console.CursorVisible = false;
            for(int i = 0; i < w.sizeY; i++){
                for(int t = 0; t < w.sizeX; t++){
                        Console.SetCursorPosition(t+w.positionX,i+w.positionY);
                        Console.Write(w.content[t,i]);
                }
            }
            Console.SetCursorPosition(0,w.sizeY);
        }

        public void CloseWindow(int windowNumber){
            windowList[windowNumber] = null;
            activeWindow = -1;
            ScreenUpdate();
        }

        int CheckFreeSpace(){
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] == null){
                    return i;
                }
            }
            return -1;
        }

        public void ScreenUpdate(){
            Console.Clear();
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] != null)
                    RenderWindow(windowList[i].positionX,windowList[i].positionY,windowList[i]);
            }
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
    }
}