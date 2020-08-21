using System.Collections.Generic;

namespace AbyssBehavior{
    public interface IWindow{
        Transform transform{get;}
        Canvas canvas{get;}
        Logic logic{get;}
        IWindow parent{get;set;}
        bool inFocus{get;}

        List<IWidget> widgets{get;}
        List<IWidget> menu{get;}
        IWidget selectedElement{get;set;}
        
        void DefaultUpdate();
        void SetFocus(bool state);
        void AddWidget(string name, IWidget widget);
        void AddMenu(string name, IWidget widget);
        IWidget GetWidget(string name);
        void RemoveWidget(string name);
    }
}