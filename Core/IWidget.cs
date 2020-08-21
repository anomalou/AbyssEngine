using System.Collections.Generic;

namespace AbyssBehavior{
    public interface IWidget{

        string name{get;set;}
        Transform transform{get;}
        WidgetCanvas canvas{get;}

        IWidget parent{get;set;}
        List<IWidget> children{get;}
        bool isVisible{get;}
        bool inFocus{get;}
        int layer{get;}
        Point GetPoint(int x, int y, int l);

        void SetParent(IWidget parent);
        void RemoveParent();
        void RemoveChild(string childName);
        void RemoveChild(IWidget child);
        void AddChild(IWidget child);
        IWidget GetChild(string name);
        IWidget[] GetChildren();
        void Update();
        void SetSize(Vector size);
        void SetVisible(bool state);
        void SetFocus(bool state);
        void SetPosition(Vector position);
        void SetData(object data);
    }
}