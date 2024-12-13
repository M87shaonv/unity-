using UnityEngine;

namespace ObjectPool
{
    public class ColorBall : MonoBehaviour
    {
        private void OnEnable()
        {
            SetRandomColor();
        }

        public void SetRandomColor()
        {
            var renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                // 获取球体的材质并设置其颜色为随机颜色
                renderer.material.color = Random.ColorHSV();
            }
            else
            {
                Debug.LogError("ColorBall must have a Renderer component with a material that supports color changes.");
            }
        }
    }
}