using System.Collections.Generic;

namespace AbyssBehavior{
    public interface IWindow{
        Logic logic{get;}
        IWindow parent{get;set;}
        bool inFocus{get;}

        List<IWidget> widgets{get;}
        List<IWidget> menu{get;}
        IWidget selectedElement{get;set;}
        Vector cursorePos{get;}
        Vector cursoreLength{get;}
        
        void DefaultUpdate();
        void SetFocus(bool state);
        void AddWidget(string name, IWidget widget);
        void AddMenu(string name, IWidget widget);
        TWidget GetWidget<TWidget>(string name) where TWidget: IWidget;
        void RemoveWidget(string name);
    }
}