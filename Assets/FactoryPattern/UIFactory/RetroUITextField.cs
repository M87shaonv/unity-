using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class RetroUITextField : MonoBehaviour, IUITextField
    {
        public void Render()
        {
            Debug.Log("Rendering a retro text field.");
        }
    }
}