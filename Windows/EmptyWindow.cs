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
                Core.CloseWindow();
            }
            if(menu.Count != 0){
                selectedElement = menu[0];
            }else{
                selectedElement = "None";
            }
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

        //Метод которые производит обновление содержимого и виджетов окна.
        public void DefaultUpdate(){
            if(logic != null)
                logic.DefaultUpdate();
            foreach(Widget w in widgets.Values){
                w.Update();
            }
            Update();
            ClearLayers();
            RenderWidgets();
        }

        protected virtual void Update(){

        }

        //Метод добавления нового виджета на окно
        protected void AddWidget(string name, Widget widget, bool menu = false){
            widgets.Add(name, widget);
            if(menu == true){
                this.menu.Add(name);
            }
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
                        canvas.Set(new Vector(x,y),l,"null");
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
                                canvas.Set(new Vector(x+w.transform.position.x,y+w.transform.position.y), 1, w.GetPoint(new Vector(x,y)));
                            }
                        }
                    }
                }
            }
        }
    }

    class Canvas{

        public int layers{get;} //слои
        public int height{get;}
        public int width{get;}
        Point[,,] canvas;

        Canvas(){

        }

        public Canvas(int heigth, int width){//инициальзация сетки
            this.height = height;
            this.width = width;
            layers = Core.buffer.layers;
            canvas = new Point[heigth, width, layers];
            for(int i = 0; i < heigth; i++){
                for(int t = 0; t < width; t++){
                    for(int f = 0; f < layers; f++){
                        canvas[i,t,f] = new Point();
                    }
                }
            }
        }

        public void LoadCanvas(string[,,] textures){
            if(textures.Length == canvas.Length){
                for(int x = 0; x < width; x++){
                    for(int y = 0; y < height; y++){
                        for(int l = 0; l < layers; l++){
                            canvas[x,y,l].SetupPoint(textures[x,y,l]);
                        }
                    }
                }
            }
        }

        public void Set(Vector pos, int layer, string texture){
            canvas[pos.x, pos.y, layer].SetupPoint(texture);
        }

        public string GetPoint(Vector pos, int layer){
            return canvas[pos.x, pos.y, layer].texture;
        }
    }
}