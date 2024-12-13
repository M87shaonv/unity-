using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class ModernUIButton : MonoBehaviour, IUIButton
    {
        public void Render()
        {
            Debug.Log("Rendering a modern button.");
        }
    }
}