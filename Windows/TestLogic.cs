namespace AbyssBehavior{
    class TestLogic:Logic{

        protected action plus, minus;

        int num;

        public TestLogic(Window parent):base(parent){

        }
        protected override void Initalization(){
            num = 0;
            plus = Plus;
            minus = Minus;
            control.Add(Control.Actions.MoveLeft, minus);
            control.Add(Control.Actions.MoveRight, plus);
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
    }
}