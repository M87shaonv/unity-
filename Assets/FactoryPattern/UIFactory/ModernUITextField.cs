using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class ModernUITextField : MonoBehaviour, IUITextField
    {
        public void Render()
        {
            Debug.Log("Rendering a modern text field.");
        }
    }
}