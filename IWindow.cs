using System;

namespace ConsoleApplication{
    interface IWindow{

        string name{get;set;}
        int sizeX{get;set;}
        int sizeY{get;set;}
        int positionX{get;set;}
        int positionY{get;set;}

        char[,,] content { get; set; }

        void Start(Source s);

        void Start(Source s, MapManager f);
        void Control(ConsoleKeyInfo key);
        int ReturnValue(string name);
        void Update();
    }
}