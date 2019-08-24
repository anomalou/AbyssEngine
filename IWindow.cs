namespace ConsoleApplication{
    interface IWindow{
        int sizeX{get;set;}
        int sizeY{get;set;}
        int positionX{get;set;}
        int positionY{get;set;}

        char[,] content{get;set;}

        void Fill(Source s);
        void Update(Source s);
    }
}