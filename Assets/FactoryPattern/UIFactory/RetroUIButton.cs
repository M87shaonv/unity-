using UnityEngine;

namespace FactoryPattern.UIFactory
{
    public class RetroUIButton : MonoBehaviour, IUIButton
    {
        public void Render()
        {
            Debug.Log("Rendering a retro button.");
        }
    }
}