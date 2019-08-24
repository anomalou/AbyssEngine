using System;

namespace ConsoleApplication{
    class GameplayWindow:IWindow{

        int _sizeX;
        int _sizeY;
        int _positionX;
        int _positionY;
        char[,] _content;
        int tx,ty;
        public int sizeX{
            get{
                return _sizeX;
            }
            set{
                _sizeX = value;
            }
        }

        public int sizeY{
            get{
                return _sizeY;
            }
            set{
                _sizeY = value;
            }
        }

        public int positionX{
            get{
                return _positionX;
            }
            set{
                _positionX = value;
            }
        }

        public int positionY{
            get{
                return _positionY;
            }
            set{
                _positionY = value;
            }
        }

        public char[,] content{
            get{
                return _content;
            }
            set{
                _content = value;
            }
        }

        public GameplayWindow(){
            sizeX = 15;
            sizeY = 15;
            content = new char[sizeX,sizeY];
        }
        public void Fill(Source s){
            for(int i = 0; i < sizeX; i++){
                for(int t = 0; t < sizeY; t++){
                    tx = s.playerX - sizeX/2 + i;
                    ty = s.playerY - sizeY/2 + t;
                    if(tx >= 0 & tx < s.GetDungeonW & ty >= 0 & ty < s.GetDungeonH)
                        content[i,t] = s.GetMapObj[tx,ty].symbol;
                    else
                        content[i,t] = ' ';
                }
            }
        }

        public void Update(Source s){
            for(int i = 0; i < sizeX; i++){
                for(int t = 0; t < sizeY; t++){
                    tx = s.playerX - sizeX/2 + i;
                    ty = s.playerY - sizeY/2 + t;
                    if(tx >= 0 & tx < s.GetDungeonW & ty >= 0 & ty < s.GetDungeonH)
                        content[i,t] = s.GetMapObj[tx,ty].symbol;
                    else
                        content[i,t] = ' ';
                }
            }
        }
    }
}