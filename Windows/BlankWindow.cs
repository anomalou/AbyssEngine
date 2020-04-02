namespace AbyssBehavior{
    class BlankWindow{

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
        Logic logic;


        public BlankWindow(){
            transform = new Transform(Vector.zero(), new Vector(width,heigth));
            Initialization();
        }

        public BlankWindow(Vector position){
            transform = new Transform(position, new Vector(width,heigth));
            Initialization();
        }

        //Метод иницализации полей окна
        public void Initialization(){
            logic = new Logic();//Заменить на свою логику
            canvas = new Canvas(heigth, width);
        }
        //Метод которые производит обновление содержимого и виджетов окна.
        public void Update(){
            logic.Update();
        }
    }

    class Canvas{

        const int layers = 2; //слои
        Point[,,] canvas;
        
        public Canvas(int heigth, int width){//инициальзация сетки
            canvas = new Point[heigth, width, layers];
            for(int i = 0; i < heigth; i++){
                for(int t = 0; t < width; t++){
                    canvas[i,t,0] = new Point();
                    canvas[i,t,1] = new Point();
                }
            }
        }
    }
}