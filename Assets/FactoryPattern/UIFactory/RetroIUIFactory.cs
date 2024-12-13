using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class RetroIUIFactory : IUIFactory
    {
        public IUIButton CreateButton()
        {
            return new GameObject("RetroButton").AddComponent<RetroUIButton>();
        }

        public IUITextField CreateTextField()
        {
            return new GameObject("RetroTextField").AddComponent<RetroUITextField>();
        }
    }
}