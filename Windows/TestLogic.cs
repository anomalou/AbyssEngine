namespace AbyssBehavior{
    class TestLogic:Logic{

        protected action plus, minus, close;

        int num;

        public TestLogic(Window parent):base(parent){
            
        }
        public override void Initialization(){
            num = 0;
            plus = Plus;
            minus = Minus;
            close = Close;
            control.Add(Control.Actions.MoveLeft, minus);
            control.Add(Control.Actions.MoveRight, plus);
            control.Add(Control.Actions.Deny, close);
        }

        void Plus(){
            if(parent.selectedElement == "counter"){
                num++;
                if(parent.GetWidget("counter")!=null)
                    parent.GetWidget("counter").SetData(num.ToString());
            }
            
        }

        void Minus(){
            if(parent.selectedElement == "counter"){
                if(num > 0)
                    num--;
                if(parent.GetWidget("counter")!=null)
                    parent.GetWidget("counter").SetData(num.ToString());
            }
            
        }

        void Close(){
            Core.CloseWindow(parent);
        }
    }
}