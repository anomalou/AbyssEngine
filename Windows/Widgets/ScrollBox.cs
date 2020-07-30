using System.Collections.Generic;

namespace AbyssBehavior{
    class ScrollBox:Widget{

        struct Cell{
            public int height;
            public int fullHeight;
        }
        List<Widget> items;
        List<Cell> cells;
        int currentScroll;
        int maxScroll;
        int spacing;

        


        public ScrollBox():base(){
            spacing = 0; 
            currentScroll = 0;
            maxScroll = 0;
            items = new List<Widget>();
            cells = new List<Cell>();
        }

        protected override void Behaviour(){
            Vector prevPosition = new Vector(transform.position.x, transform.position.y - spacing);
            foreach(Widget w in items){
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
            Cell cell;
            cell.height = item.transform.scale.y;
            cell.fullHeight = cell.height + spacing;
            items.Add(item);
            cells.Add(cell);
            maxScroll++;
        }

        public void RemoveItem(Widget item){
            if(items.Contains(item)){
                int index = items.IndexOf(item);
                items.Remove(item);
                cells.RemoveAt(index);
                maxScroll--;
            }else
                Core.ThrowError(9);
        }

        public void SetSpacing(int width){
            spacing = width;
        }
    }
}