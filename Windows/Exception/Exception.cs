using System.Collections.Generic;
using System;

namespace AbyssBehavior{
    class ExceptionDesc:Window{
        protected override void Initialization(){
            SetLogic(new ExceptionDescLogic(this));
            
            TextBox text = new TextBox("Error occupated! Please fix that errors and restart core!");
            text.SetPosition(new Vector(1,1));
            ScrollBox errorList = new ScrollBox();
            errorList.SetSpacing(1);
            
            errorList.SetPosition(new Vector(1, 3));
            errorList.SetSize(new Vector(62, 31));

            AddWidget("text", text);
            AddWidget("errorList", errorList);
        }
    }

    class ExceptionDescLogic:Logic{

        public ExceptionDescLogic(IWindow window):base(window){}

        public override void Initialization(){
            control.Add(KeysToAction.Actions.Deny, Exit);
            Connect("errorMsg", SetErrors);
        }

        protected override void Update(){
            
        }

        protected void Exit(){
            Core.Exit();
        }

        protected void SetErrors(object msg){
            List<Exception> msgs = (List<Exception>)msg;
            ScrollBox eL = window.GetWidget<ScrollBox>("errorList");
            foreach(IWidget w in eL.children){
                eL.RemoveItem(w);
                window.RemoveWidget(w.identificator);
            }
            int i = 1;
            foreach(Exception e in msgs){
                TextBox error = new TextBox(i+":"+e.Message+" in "+e.Source);
                error.SetSize(new Vector(62, 1));
                window.GetWidget<ScrollBox>("errorList").AddChild(error);
                eL.AddItem(error);
                window.AddMenu("e"+i, error);
                i++;
            }
            Core.errorList.Clear();
        }
    }
}