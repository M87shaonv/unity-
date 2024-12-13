using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class UIFactoryController : MonoBehaviour
    {
        private IUIButton _button;
        private IUITextField _textField;

        private void Start()
        {
            // 选择你想要使用的工厂
            IUIFactory factory = GetSelectedFactory();

            // 使用选定的工厂创建UI元素
            _button = factory.CreateButton();
            _textField = factory.CreateTextField();

            // 渲染UI元素
            _button.Render();
            _textField.Render();
        }

        private IUIFactory GetSelectedFactory()
        {
            // 这里可以根据某些条件选择不同的工厂
            return new ModernIUIFactory(); // 或者 new RetroGuiFactory();
        }
    }
}