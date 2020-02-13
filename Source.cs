using System;

namespace AbyssBehaviours
{
    class Source
    {
        bool isWork;

        Vector windowSize;
        IWindow[] windowList;
        int activeWindow;
        //static string[] debugOutput;

        Source source;
        object[] debug;

        int GWID; //global window ID

        static void Main(string[] args)
        {   
            Source s = new Source();
            s.GWID = 0;
            s.source = s;
            s.isWork = true;
            s.windowSize = new Vector(40, 40);
            ConsoleKeyInfo key;
            s.debug = new object[24];
            s.GameLaunch();
            int wid;
            while(s.isWork){
                if (s.activeWindow != -1)
                {
                    wid = s.FindWindow(s.activeWindow);
                    if(wid != -1){
                        s.UpdateWindow(s.windowList[wid]);
                        key = Console.ReadKey();
                        s.windowList[wid].Control(key);
                    }else
                        s.AddDebug("(ES000)No have windows");
                }
            }
        }

        void GameLaunch(){
            windowList = new IWindow[5]{new BlankWindow(), new BlankWindow(), new BlankWindow(), new BlankWindow(), new BlankWindow()};//how many windows have game
            Console.CursorVisible = false;
            Console.BufferHeight = windowSize.Y();
            Console.WindowWidth = windowSize.X();
            Console.BufferWidth = windowSize.X();
            Console.WindowHeight = windowSize.Y();
            Console.Title = "DungeonSeeker";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            OpenWindow(new Vector(0,0), new GameplayWindow(), new MapManager());//set gameplay window as active window
        }

        //canvas control

        public int OpenWindow(Vector vector,IWindow window){
            int i = CheckFreeSpace();
            if(i != -1){
                window.Start(source);
                AddDebug("(IS)Opened " + GWID);
                RenderWindow(vector,window);
                windowList[i] = window;
                windowList[i].WID = GWID;
                SetActive(windowList[i].WID);
                GWID++;
                return windowList[i].WID;
            }else
                AddDebug("(ES001)Can't open new window");
            return -1;
        }

        public int OpenWindow(Vector vector, IWindow w, MapManager f){
            int i = CheckFreeSpace();
            if(i != -1){
                w.Start(source,f);
                AddDebug("(IS)Opened " + GWID);
                RenderWindow(vector, w);
                windowList[i] = w;
                windowList[i].WID = GWID;
                SetActive(windowList[i].WID);
                GWID++;
                return windowList[i].WID;
            }else
                AddDebug("(ES001)Can't open new window");
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
                    Console.ForegroundColor = w.container.GetPixel(new Vector(t,i)).GetColor();
                    Console.Write(w.container.GetPixel(new Vector(t,i)).GetCharacter());
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(w.position.X(),w.position.Y());
        }

        public void CloseWindow(int WID){
            int i = FindWindow(WID);
            int wid = PreviousWindow(WID);
            AddDebug("(IS)Finded " + i);
            AddDebug("(IS)Prev " + wid);
            if (i == -1)
                AddDebug("(ES002)Window not founded!");
            else{
                if(wid != -1){
                    SetActive(wid);
                    windowList[i] = new BlankWindow();
                    GWID--;
                }else{   
                    AddDebug("(ES003)No have prev window");
                    Exit();
                }
            }
            ScreenUpdate();
        }

        int CheckFreeSpace(){
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i].WID == -1){
                    return i;
                }
            }
            return -1;
        }

        int FindWindow(int WID)
        {
            for(int i = 0; i < windowList.Length; i++)
            {
                if (windowList[i].WID == WID)
                    return i;
            }
            return -1;
        }

        int PreviousWindow(int WID){
            int wid = -1;
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i].WID < WID && windowList[i].WID > wid)
                    wid = windowList[i].WID;
            }
            return wid;
        }        
        public void ScreenUpdate(){
            Console.Clear();
            for(int i = 0; i < windowList.Length; i++){
                if(windowList[i].WID != -1)
                    RenderWindow(windowList[i].position,windowList[i]);
            }
        }

        public void SetActive(int WID)
        {
            activeWindow = WID;
        }

        public int GetActive()
        {
            return activeWindow;
        }

        public IWindow windowLobby(int WID)
        {
            for(int i = 0; i < windowList.Length; i++)
            {
                if (windowList[i].WID == WID)
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

        public void AddDebug(Object output){
            for(int i = debug.Length - 1; i > 0; i--){
                debug[i] = debug[i - 1];
            }
            debug[0] = output;
        }

        public string GetDebug(int num){
            if(debug[num] != null)
                return debug[num].ToString();
            else
                return "";
        }

        public void Exit()
        {
            isWork = false;
        }
    }
}

