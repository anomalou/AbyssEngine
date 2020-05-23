using System.Collections.Generic;

namespace AbyssBehavior{
    class Window{

        /*В данном пустом окне описан пример создания простейшего окна, которе сможет отобразить ядро Abyss.
        Каждое новое окно должно создаваться основываясь на данном примере и должно следовать данной структуре.
        Вся логика(упраление, алгоритмы) должна быть в виде отдельных файлов и должно быть независимым от окна.
        Окно это лишь средство отображения, а не рабочий инстурмент. Оно не должно быть перегруженно лишним функционалом
        дабы не вносить хаос в дальнейшей разработке. Так же каждое новое окно должно наследоваться от данного класса.*/

        //Здесь находятся базовые параметры окна как его высота и ширина. Они задаются только в коде и для доступа к ним
        //необходимо обращаться к полю transform, которое может лишь вернуть размер scale, т.к.  изменить его нельзя.
        //В отличии от scale поле transform.position можно изменить, но только при помощи присвоения к нему Vector.

        //Canvas это сетка окна. В ней находится все его содержимое, которое затем отобразится на экране.
        //Его можно изменить напрямую, но делать это не желательно, так как в дальнейшем может возникнуть путаница.
        //Для изменения его содержимого должны использоваться, так называемые Widgets. Они могут спокойно редакитировать
        //canvas, но получить с него сведения нет.

        public Transform transform;
        public Canvas canvas;
        public Logic logic;
        public Window parent;

        Dictionary<string, Widget> widgets;
        public List<string> menu;
        public string selectedElement;


        public Window(){
            transform = new Transform(Vector.zero());
            DefaultInitialization();
        }

        public Window(Vector position){
            transform = new Transform(position);
            DefaultInitialization();
        }

        //Стандартный метод иницализации полей окна. Его трогать нельзя
        protected void DefaultInitialization(){
            widgets = new Dictionary<string, Widget>();
            menu = new List<string>();
            Initialization();
            if(transform.scale != null)
                canvas = new Canvas(transform.scale.x, transform.scale.y);
            else
                canvas = new Canvas(1, 1);
            if(logic == null){
                Core.ThrowError(1);
                Core.CloseWindow(this);
            }
            if(menu.Count != 0){
                selectedElement = menu[0];
            }else{
                selectedElement = "None";
            }
            PostInitialization();
        }

        //Пользовательский метод инциальзации. Его можно переписать под себя
        protected virtual void Initialization(){
            transform.SetupScale(new Vector(10,3));//установить размер окна
            logic = new Logic(this);//Заменить на свою логику
            // menu.Add("one");
            // menu.Add("two");
            // menu.Add("three");
            // menu.Add("four");
        }

        protected virtual void PostInitialization(){

        }

        //Метод которые производит обновление содержимого и виджетов окна.
        public void DefaultUpdate(){
            if(Core.currentWindow == this){
                if(logic != null)
                logic.DefaultUpdate();
                foreach(Widget w in widgets.Values){
                    w.Update();
                }
                Update();
                ClearLayers();
                RenderWidgets();
                RenderCursore();
            }
        }

        protected virtual void Update(){

        }

        //Метод добавления нового виджета на окно
        protected void AddWidget(string name, Widget widget, object widgetData){
            if(widgets.ContainsKey(name) == false){
                widgets.Add(name, widget);
                widgets[name].SetData(widgetData);
            }else
                Core.ThrowError(4);
        }

        protected void AddMenu(string name, Widget widget, object widgetData){
            if(widgets.ContainsKey(name) == false){
                widgets.Add(name, widget);
                menu.Add(name);
                widgets[name].SetData(widgetData);
            }else
                Core.ThrowError(4);
        }

        public Widget GetWidget(string name){
            if(widgets.ContainsKey(name))
                return widgets[name];
            else
                return null;
        }

        void ClearLayers(){
            for(int x = 0; x < transform.scale.x; x++){
                for(int y = 0; y < transform.scale.y; y++){
                    for(int l = 1; l < canvas.layers; l++){
                        canvas.Set(x,y,l,"null");
                    }
                }
            }
        }

        void RenderWidgets(){
            foreach(Widget w in widgets.Values){
                //System.Console.WriteLine(w.transform.scale.x);
                for(int x = 0; x < w.transform.scale.x; x++){
                    if(x+w.transform.position.x < transform.scale.x){
                        for(int y = 0; y < w.transform.scale.y; y++){
                            if(y+w.transform.position.y < transform.scale.y){
                                canvas.Set(x+w.transform.position.x,y+w.transform.position.y, 1, w.GetPoint(x,y));
                            }
                            else
                                break;
                        }
                    }else
                        break;
                }
            }
        }

        void RenderCursore(){
            if(selectedElement != "None"){
                Vector pos,scale;
                pos = new Vector(widgets[selectedElement].transform.position.x, widgets[selectedElement].transform.position.y);
                scale = new Vector(widgets[selectedElement].transform.scale.x, widgets[selectedElement].transform.scale.y);
                canvas.Set(pos.x, pos.y + scale.y - 1, 3, "cursoreL");
                canvas.Set(pos.x+scale.x - 1, pos.y+scale.y - 1, 3, "cursoreR");
            }
        }
    }

    class Canvas{

        public int layers{get;} //слои
        public int heigth{get;}
        public int width{get;}
        public Point[,,] canvas;

        Canvas(){

        }

        public Canvas(int width, int heigth){//инициальзация сетки
            this.heigth = heigth;
            this.width = width;
            layers = Core.buffer.layers;
            canvas = new Point[width, heigth, layers];
            for(int i = 0; i < width; i++){
                for(int t = 0; t < heigth; t++){
                    for(int f = 0; f < layers; f++){
                        canvas[i,t,f] = new Point();
                    }
                }
            }
        }

        public void LoadCanvas(string[,] textures){
            if(textures.Length == canvas.Length / layers){
                for(int x = 0; x < width; x++){
                    for(int y = 0; y < heigth; y++){
                        canvas[x,y,0].SetupPoint(textures[x,y]);
                    }
                }
            }
        }

        public void Set(int x, int y, int layer, string texture_name){
            canvas[x, y, layer].SetupPoint(texture_name);
        }

        public string GetPoint(int x, int y, int layer){
            return canvas[x, y, layer].texture;
        }
    }
}