using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace AbyssBehavior{
    static class Core{

        public static Buffer buffer;
        static GraphicRender graphicCore;

        public static List<Window> windowQueue;
        public static Window currentWindow;

        public static bool active;
        static void Main(string[] arg)
        {
            Initialization();
        }

        static void Initialization(){
            buffer = new Buffer();
            windowQueue = new List<Window>();
            active = true;
            OpenWindow(new MainMenu());
            Objects.Initalization();
            using(graphicCore = new GraphicRender())
                graphicCore.Run();
            
        }

        public static void Update(){
            if(windowQueue.Count > 0 && currentWindow != null){
                Render();
                foreach(Window w in windowQueue.ToArray()){
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

        public static void OpenWindow(Window window, Window parent = null){
            windowQueue.Add(window);
            currentWindow = window;
            if(parent != null){
                currentWindow.parent = parent;
            }
        }

        public static void OpenInfo(string text){

        }

        public static void CloseWindow(Window window){
            if(window == currentWindow)
                if(window.parent != null)
                    currentWindow = window.parent;
                else
                    if(windowQueue.Count > 0)
                        currentWindow = windowQueue[0];
                    else
                        currentWindow = null;
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

        public enum Actions{
            None = 0,
            Accept = 1,
            Deny = 2,
            MoveUp = 3,
            MoveDown = 4,
            MoveLeft = 5,
            MoveRight = 6,
            CursoreUp = 7,
            CursoreDown = 8,
            CursoreLeft = 9,
            CursoreRight = 10,
            Action = 11
        }
        const int couldownTimeMax = 10;
        static Dictionary<Keys, Actions> configurations;

        public static Actions action;
        static KeyboardState state;
        public static bool couldown;
        public static int couldownTime;
        
        
        public static void InitializateConfig(){
            couldown = false;
            couldownTime = 0;
            configurations = new Dictionary<Keys, Actions>();
            configurations.Add(Keys.Enter, Actions.Accept);
            configurations.Add(Keys.Escape, Actions.Deny);
            configurations.Add(Keys.Up, Actions.CursoreUp);
            configurations.Add(Keys.Down, Actions.CursoreDown);
            configurations.Add(Keys.Left, Actions.CursoreLeft);
            configurations.Add(Keys.Right, Actions.CursoreRight);
            configurations.Add(Keys.P, Actions.Action);
            configurations.Add(Keys.W, Actions.MoveUp);
            configurations.Add(Keys.S, Actions.MoveDown);
            configurations.Add(Keys.A, Actions.MoveLeft);
            configurations.Add(Keys.D, Actions.MoveRight);
        }

        
        public static void Controlling(Keys[] keys){
            state = Keyboard.GetState();
            if(keys.Length != 0 && Core.active == true && couldown == false){
                if(configurations.ContainsKey(keys[keys.Length-1])){
                    if(state.IsKeyDown(keys[keys.Length - 1])){
                        action = configurations[keys[keys.Length - 1]];
                        couldown = true;
                    }
                }
            }
            else{
                action = Actions.None;
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

    class Transform{
        public class Position{
            int _x;
            int _y;

            public int x{get{return _x;}}
            public int y{get{return _y;}}
            public static implicit operator Position(Vector v){
                return new Position{_x = v.x, _y = v.y};
            }

            public override string ToString(){
                return  _x+"-"+_y;
            }

            public static Vector operator+(Vector v, Position p){
                return new Vector(v.x+p._x,v.y+p._y);
            }
            Position(){

            }
        }

        public class Scale{
            int _x;
            int _y;

            public int x{get{return _x;}}
            public int y{get{return _y;}}
            public static implicit operator Scale(Vector v){
                return new Scale{_x = v.x, _y = v.y};
            }
            
            public override string ToString(){
                return  _x+"-"+_y;
            }
            Scale(){

            }
        }

        Position _position;
        Scale _scale;
        public Position position{get{return _position;}set{_position = value;}}
        public Scale scale{get{return _scale;}}

        
        public Transform(){
            _position = new Vector();
            _scale = new Vector(1,1);
        }

        public Transform(Vector position){
            _position = position;
        }

        public Transform(Vector position, Vector scale){
            _position = position;
            _scale = scale;
        }

        public bool SetupScale(Vector scale){
            if(this._scale == null){
                _scale = scale;
                return true;
            }
            return false;
        }

    }

    class Vector{
        int _x;
        int _y;

        public Vector(){
            _x = 0;
            _y = 0;
        }
        public Vector(Vector v){
            _x = v.x;
            _y = v.y;
        }
        public Vector(int x, int y){
            _x = x;
            _y = y;
        }

        public int x{get{return _x;}}
        public int y{get{return _y;}}

        public static Vector zero(){
            return new Vector(0,0);
        }
    }

    static class Time{

        static long _msc;
        public static long msc{get{return _msc;}set{if(value > 1000000000000) _msc = 0; else _msc = value;}}
        public static int seconds;
        public static int minutes;
        public static long hours;
    }
}