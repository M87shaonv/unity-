using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class ModernIUIFactory : IUIFactory
    {
        public IUIButton CreateButton()
        {
            return new GameObject("ModernButton").AddComponent<ModernUIButton>();
        }

        public IUITextField CreateTextField()
        {
            return new GameObject("ModernTextField").AddComponent<ModernUITextField>();
        }
    }
}