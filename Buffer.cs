using System;
using Microsoft.Xna.Framework;

namespace AbyssBehavior{
    class Buffer{

        const int width = 64; //ширина
        const int heigth = 36; //высота
        const int layers = 2; //глубина

        Cursore cursore;

        public bool consoleLike;
        
        Point[,,] buffer;
        public Buffer(){
            cursore = new Cursore();
            buffer = new Point[width, heigth, layers];
            consoleLike = false;
            for(int i = 0; i < width; i++){
                for(int t = 0; t < heigth; t++){
                    buffer[i,t,0] = new Point();
                    buffer[i,t,1] = new Point();
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
            buffer[cursore.x, cursore.y, cursore.layer].SetupPoint(texture_name);
            if(consoleLike == true){
                cursore.Move();
            }
        }

        public void SetCursore(int x, int y, int layer){
            while(x > width || x < width){
                if(x > width){
                    x = x - width;
                    y++;
                }else if(x < width){
                    x = 1;
                }
            }
            
            if(y > heigth){
                y = heigth;
            }else if(y < heigth){
                y = 1;
            }
            cursore.chPos(x,y,layer);
        }
    }

    class Point{
        Color color;
        string texture_name;
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
            _x = x - 1;
            _y = y - 1;
            _layer = layer - 1;
        }
        public void Move(){
            _x++;
        }
    }
}