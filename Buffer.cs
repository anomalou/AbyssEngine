using System;
using Microsoft.Xna.Framework;

namespace AbyssBehavior{
    class Buffer{

        const int _width = 51; //ширина
        const int _heigth = 28; //высота

        public int width{get{return _width;}}
        public int heigth{get{return _heigth;}}
        

        /*Разные слои для интерфейса, активных элементов и элементов управления.
        На 0 уровне находится статичная графика, которая в ходе работы никак не меняется.
        На 1-2 уровне находятся активные элементы, которые могут меняться в ходе работы.
        На 3 уровне находятся элементы управления, которые могут накладываться на активные элементы. К примеру это курсор*/
        const int _layers = 4; //слои
        public int layers{get{return _layers;}}

        Cursore cursore;

        public bool consoleLike;
        
        Point[,,] buffer;

        public string GetTexture(int x, int y, int layer){
            return buffer[x, y, layer].texture;
        }
        public Buffer(){
            cursore = new Cursore();
            buffer = new Point[width, heigth, layers];
            consoleLike = false;
            for(int i = 0; i < width; i++){
                for(int t = 0; t < heigth; t++){
                    for(int f = 0; f < layers; f++){
                        buffer[i,t,f] = new Point();
                    }
                }
            }
        }
        public void SetPoint(){
            buffer[cursore.x, cursore.y, cursore.layer].SetupPoint();
            if(consoleLike == true){
                cursore.Move();
            }
        }
        public void SetPoint(string texture_name){
            //Console.WriteLine(texture_name);
            buffer[cursore.x, cursore.y, cursore.layer].SetupPoint(texture_name);
            if(consoleLike == true){
                cursore.Move();
            }
        }

        public void SetPoint(Point p){
            buffer[cursore.x, cursore.y, cursore.layer].SetupPoint(p);
            
            if(consoleLike == true){
                cursore.Move();
            }
        }

        public void SetCursore(int x, int y, int layer){
            while(x >= width || x < 0){
                if(x >= width){
                    x = x - width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= heigth){
                y = heigth;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= layers)
                layer = layers;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);
        }

        public void SetCursore(Vector v, int layer){
            int x = v.x;
            int y = v.y;
            while(x >= width || x < 0){
                if(x > width){
                    x = x - width;
                    y++;
                }else if(x < 0){
                    x = 0;
                }
            }
            
            if(y >= heigth){
                y = heigth;
            }else if(y < 0){
                y = 0;
            }

            if(layer >= layers)
                layer = layers;
            else if(layer < 0)
                layer = 0;
            cursore.chPos(x,y,layer);

        }
    }

    class Point{
        Color color;
        string texture_name;

        public string texture{get{return texture_name;}}
        public Point(){
            color = Color.White;
            texture_name = "null";
        }
        public Point(string texture_name){
            color = Color.White;
            this.texture_name = texture_name;
        }
        public Point(Color color, string texture_name){
            this.color = color;
            this.texture_name = texture_name;
        }
        public void SetupPoint(){
            color = Color.White;
            texture_name = "null";
        }
        public void SetupPoint(string texture_name){
            color = Color.White;
            this.texture_name = texture_name;
        }

        public void SetupPoint(Point p){
            color = p.color;
            texture_name = p.texture_name;
        }
    }

    class Cursore{
        int _x;
        int _y;
        int _layer;

        public int x{get{return _x;}}
        public int y{get{return _y;}}
        public int layer{get{return _layer;}}
        public Cursore(){
            _x = 0;
            _y = 0;
            _layer = 0;
        }
        public void chPos(int x, int y, int layer){
            _x = x;
            _y = y;
            _layer = layer;
            //Console.WriteLine(x+" "+y+" "+layer);
        }
        public void Move(){
            _x++;
        }
    }
}