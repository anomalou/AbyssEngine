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

        const int heigth = 3;//высота
        const int width = 10;//ширина
        public Transform transform;
        public Canvas canvas;
        public Logic logic;

        Dictionary<string, Widget> widgets;
        public List<string> menu;
        public string selectedElement;


        public Window(){
            transform = new Transform(Vector.zero(), new Vector(width,heigth));
            DefaultInitialization();
        }

        public Window(Vector position){
            transform = new Transform(position, new Vector(width,heigth));
            DefaultInitialization();
        }

        //Стандартный метод иницализации полей окна. Его трогать нельзя
        protected void DefaultInitialization(){
            canvas = new Canvas(heigth, width);
            widgets = new Dictionary<string, Widget>();
            menu = new List<string>();
            Initialization();
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
            logic = new Logic(this);//Заменить на свою логику
            menu.Add("one");
            menu.Add("two");
            menu.Add("three");
            menu.Add("four");
        }

        //Метод которые производит обновление содержимого и виджетов окна.
        public void DefaultUpdate(){
            if(logic != null)
                logic.DefaultUpdate();
            Update();
        }

        protected virtual void Update(){

        }

        //Метод добавления нового виджета на окно
        protected void AddWidget(string name, Widget widget, Vector position, bool menu = false){
            widgets.Add(name, widget);
            if(menu == true){
                this.menu.Add(name);
            }
        }
    }

    class Canvas{

        const int layers = 4; //слои
        Point[,,] canvas;

        Canvas(){

        }

        public Canvas(int heigth, int width){//инициальзация сетки
            canvas = new Point[heigth, width, layers];
            for(int i = 0; i < heigth; i++){
                for(int t = 0; t < width; t++){
                    for(int f = 0; f < layers; f++){
                        canvas[i,t,f] = new Point();
                    }
                }
            }
        }

        public Point GetStaticPoint(Vector pos){
            return canvas[pos.x, pos.y, 0];
        }

        public Point GetWidgetPoint0(Vector pos){
            return canvas[pos.x, pos.y, 1];
        }

        public Point GetWidgetPoint1(Vector pos){
            return canvas[pos.x, pos.y, 2];
        }

        public Point GetCursorePoint(Vector pos){
            return canvas[pos.x, pos.y, 4];
        }
    }
}