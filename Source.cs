using System;

namespace ConsoleApplication
{
    class Source
    {
        bool isWork;

        Vector windowSize;
        IWindow[] windowList;
        int activeWindow;
        string[] debugOutput;

        Source source;

        static void Main(string[] args)
        {   
            Source s = new Source();
            s.source = s;
            s.isWork = true;
            s.windowSize = new Vector(30, 60);
            ConsoleKeyInfo key;
            s.GameLaunch();
            while(s.isWork){
                if (s.activeWindow != -1)
                {
                    s.UpdateWindow(s.windowList[s.activeWindow]);
                    key = Console.ReadKey();
                    s.windowList[s.activeWindow].Control(key);
                }
            }
        }

        void GameLaunch(){
            windowList = new IWindow[3];//how many windows have game
            Console.CursorVisible = false;
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SetActive(OpenWindow(new Vector(0,0), new GameplayWindow(), new MapManager()));//set gameplay window as active window
        }

        //canvas control

        public int OpenWindow(Vector vector,IWindow window){
            int i = CheckFreeSpace();
            if(i != -1){
                window.Start(source);
                RenderWindow(vector,window);
                windowList[i] = window;
                return i;
            }
            return -1;
        }

        public int OpenWindow(Vector vector, IWindow w, MapManager f){
            int i = CheckFreeSpace();
            if(i != -1){
                w.Start(source,f);
                RenderWindow(vector, w);
                windowList[i] = w;
                return i;
            }
            return -1;
        }

        public void RenderWindow(Vector vector,IWindow w){
            w.position = vector;
            UpdateWindow(w);
        }

        public void UpdateWindow(IWindow w){
            w.Update();
            Console.CursorVisible = false;
            for(int i = 0; i < w.size.Y(); i++){
                for(int t = 0; t < w.size.X(); t++){
                    Console.SetCursorPosition(t+w.position.X(),i+w.position.Y());
                    Console.ForegroundColor = Colors.Color(w.content[t, i, 1]);
                    Console.Write(w.content[t,i,0]);
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(w.position.X(),w.position.Y());
        }

        public void CloseWindow(int windowNumber){
            windowList[windowNumber] = null;
            int i = FindWindow();
            if (i != -1)
                SetActive(i);
            else
                SetActive(-1);
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

        int FindWindow()
        {
            for(int i =0; i < windowList.Length; i++)
            {
                if (windowList[i] != null)
                    return i;
            }
            return -1;
        }

        public void ScreenUpdate(){
            Console.Clear();
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i] != null)
                    RenderWindow(windowList[i].position,windowList[i]);
            }
        }

        public void SetActive(int num)
        {
            activeWindow = num;
        }

        public int GetActive()
        {
            return activeWindow;
        }

        public IWindow windowLobby(string name)
        {
            for(int i = 0; i < windowList.Length; i++)
            {
                if (windowList[i].name == name)
                    return windowList[i];
            }
            return null;
        }

        //properties

        /*public int WindowSizeH{
            get{
                return _windowSizeH;
            }
        }

        public int WindowSizeW{
            get{
                return _windowSizeW;
            }
        }*/

        public void Exit()
        {
            isWork = false;
        }
    }
}