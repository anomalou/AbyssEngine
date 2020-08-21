namespace AbyssBehavior{
    class ErrorWithPluginLogic:Logic{
        public ErrorWithPluginLogic(Window parent):base(parent){}
        public override void Initialization(){
            control.Add(KeysToAction.Actions.Deny, Exit);
        }

        protected void Exit(){
            Core.CloseWindow(window);
        }
    }
}