namespace FactoryPattern.UIFactory
{
    public interface IUIFactory
    {
        IUIButton CreateButton();
        IUITextField CreateTextField();
    }
}