namespace AbyssBehavior{
    public interface IWindowLogic{
        void DefaultUpdate();
        void Initialization();
        void SetCurrentAction(KeysToAction.Actions action);
    }
}