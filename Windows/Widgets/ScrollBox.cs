using System.Collections.Generic;

namespace AbyssBehavior{
    class ScrollBox:Widget{

        List<Widget> items;
        int currentScroll;
        int maxScroll;
        int spacing;

        


        public ScrollBox():base(){
            spacing = 0; 
            currentScroll = 0;
            maxScroll = 0;
            items = new List<Widget>();
            SetSize(new Vector(1, 3));
        }

        protected override void Behaviour(){
            Vector prevPosition = new Vector(transform.position.x, transform.position.y - spacing);
            foreach(Widget w in items){
                if(w.transform.scale.x > transform.scale.x)
                    SetSize(new Vector(w.transform.scale.x, transform.scale.y));
                if(w.transform.scale.y > transform.scale.y)
                    SetSize(new Vector(transform.scale.x, w.transform.scale.y));
                if(w.inFocus){
                    currentScroll = items.IndexOf(w);
                }
                w.SetVisible(true);
            }
            int index = currentScroll - 1;
            if(index > -1){
                for(int i = index; i < maxScroll; i++){
                    if((items[i].transform.scale.x <= transform.scale.x) && (items[i].transform.scale.y <= transform.scale.y) && (prevPosition.y + spacing < (transform.position.y + transform.scale.y))){
                        items[i].transform.position = new Vector(prevPosition.x, prevPosition.y + spacing);
                        prevPosition = new Vector(items[i].transform.position.ToVector().x, items[i].transform.position.ToVector().y + items[i].transform.scale.y);
                    }else{
                        items[i].SetVisible(false);
                    }
                }
                for(int i = 0; i < index; i++){
                    items[i].SetVisible(false);
                }
            }else{
                foreach(Widget w in items){
                    w.SetVisible(true);
                    if((w.transform.scale.x <= transform.scale.x) && (w.transform.scale.y <= transform.scale.y) && (prevPosition.y + spacing < (transform.position.y + transform.scale.y))){
                        w.transform.position = new Vector(prevPosition.x, prevPosition.y + spacing);
                        prevPosition = new Vector(w.transform.position.ToVector().x, w.transform.position.ToVector().y + w.transform.scale.y);
                    }else{
                        w.SetVisible(false);
                    }
                }
            }
            // foreach(Widget w in items){
            //     w.SetVisible(true);
            //     if((w.transform.scale.x <= transform.scale.x) && (w.transform.scale.y <= transform.scale.y) && (prevPosition.y + spacing < (transform.position.y + transform.scale.y))){
            //         w.transform.position = new Vector(prevPosition.x, prevPosition.y + spacing);
            //         prevPosition = new Vector(w.transform.position.ToVector().x, w.transform.position.ToVector().y + w.transform.scale.y);
            //     }else{
            //         w.SetVisible(false);
            //     }
            // }
        }

        protected override void Render(){

        }

        public void AddItem(Widget item){
            items.Add(item);
            maxScroll++;
        }

        public void RemoveItem(Widget item){
            if(items.Contains(item)){
                int index = items.IndexOf(item);
                items.Remove(item);
                maxScroll--;
            }else
                Core.ThrowError(9);
        }

        public void SetSpacing(int width){
            if(transform.scale.ToVector() == new Vector(1, (spacing + 1) * 3))
                SetSize(new Vector(1, (width + 1) * 3));
            spacing = width;
        }
    }
}