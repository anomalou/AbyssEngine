using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AbyssLibraries;

namespace AbyssBehavior{
    static class Core{
        public static Buffer buffer;
        static GraphicRender graphicCore;

        public static List<IWindow> windowQueue;
        public static IWindow currentWindow;

        public static bool active;
        
        static void Main(string[] arg)
        {
            Initialization();
        }

        static void Initialization(){
            buffer = new Buffer();
            windowQueue = new List<IWindow>();
            active = true;
            SwapBuffer.Initialization();
            GameCore.Initialization();
            PluginManager.PrepareSpace();
            PluginManager.LoadPlugins();
            OpenWindow(new MainMenu());
            Objects.Initalization();
            using(graphicCore = new GraphicRender())
                graphicCore.Run();
            
        }

        public static void Update(){
            GameCore.Update();
            if(windowQueue.Count > 0 && currentWindow != null){
                Render();
                foreach(IWindow w in windowQueue.ToArray()){
                    w.DefaultUpdate();
                }
            }
        }

        static void Render(){
            for(int i = 0; i < currentWindow.transform.scale.y; i++){
                for(int t = 0; t < currentWindow.transform.scale.x; t++){
                    for(int f = 0; f < currentWindow.canvas.layers; f++){
                        buffer.SetCursore(t+currentWindow.transform.position.x,i+currentWindow.transform.position.y,f);
                        buffer.SetPoint(currentWindow.canvas.GetPoint(t,i,f));
                    }
                }
            }
        }

        public static void OpenWindow(IWindow window, IWindow parent = null){
            windowQueue.Add(window);
            if(currentWindow != null)
                currentWindow.SetFocus(false);
            currentWindow = window;
            window.SetFocus(true);
            if(parent != null){
                currentWindow.parent = parent;
            }
        }

        public static void OpenInfo(string text){

        }

        public static void CloseWindow(IWindow window){
            if(window == currentWindow)
                if(window.parent != null){
                    currentWindow = window.parent;
                    window.parent.SetFocus(true);
                }else
                    if(windowQueue.Count > 0){
                        currentWindow = windowQueue[0];
                        windowQueue[0].SetFocus(true);
                    }else
                        currentWindow = null;
            window.SetFocus(false);
            windowQueue.Remove(window);
            buffer.Clear();
        }

        public static void ThrowError(int errorCode){

        }

        public static void Exit(){
            graphicCore.Exit();
        }
    }

    static class Control{

        const int couldownTimeMax = 10;
        static Dictionary<Keys, KeysToAction.Actions> configurations;

        // public static Actions action;
        static KeyboardState state;
        public static bool couldown;
        public static int couldownTime;
        
        
        public static void InitializateConfig(){
            couldown = false;
            couldownTime = 0;
            configurations = new Dictionary<Keys, KeysToAction.Actions>();
            configurations.Add(Keys.Enter, KeysToAction.Actions.Accept);
            configurations.Add(Keys.Escape, KeysToAction.Actions.Deny);
            configurations.Add(Keys.Up, KeysToAction.Actions.CursoreUp);
            configurations.Add(Keys.Down, KeysToAction.Actions.CursoreDown);
            configurations.Add(Keys.Left, KeysToAction.Actions.CursoreLeft);
            configurations.Add(Keys.Right, KeysToAction.Actions.CursoreRight);
            configurations.Add(Keys.P, KeysToAction.Actions.Action);
            configurations.Add(Keys.W, KeysToAction.Actions.MoveUp);
            configurations.Add(Keys.S, KeysToAction.Actions.MoveDown);
            configurations.Add(Keys.A, KeysToAction.Actions.MoveLeft);
            configurations.Add(Keys.D, KeysToAction.Actions.MoveRight);
        }

        
        public static void Controlling(Keys[] keys){
            state = Keyboard.GetState();
            if(keys.Length != 0 && Core.active == true && couldown == false){
                if(configurations.ContainsKey(keys[keys.Length-1])){
                    if(state.IsKeyDown(keys[keys.Length - 1])){
                        // action = configurations[keys[keys.Length - 1]];
                        if(Core.currentWindow != null)
                            Core.currentWindow.logic.SetCurrentAction(configurations[keys[keys.Length - 1]]);
                        couldown = true;
                    }
                }
            }
            else{
                if(Core.currentWindow != null)
                    Core.currentWindow.logic.SetCurrentAction(KeysToAction.Actions.None);
                // action = Actions.None;
                if(couldown == true){
                    couldownTime++;
                    if(couldownTime > couldownTimeMax){
                        couldownTime = 0;
                        couldown = false;
                    }
                }
            }
        }
    }
}