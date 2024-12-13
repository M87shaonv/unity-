using UnityEngine;

namespace MementoPattern
{
public class Apple : MonoBehaviour
    {
        private float speed = 5f;
        private float rotationSpeed = 30f;

        private void Start()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                HandleRotation();
            }
            else
            {
                HandleMovement();
            }
        }

        private void HandleMovement()
        {
            // 初始化水平和垂直移动量为0
            var horizontal = 0f;
            var vertical = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                horizontal -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontal += 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                vertical += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                vertical -= 1;
            }

            Vector3 movement = new Vector3(horizontal, vertical, 0) * (speed * Time.deltaTime);
            transform.Translate(movement, Space.World);
        }

        private void HandleRotation()
        {
            // 初始化水平和垂直旋转量为0
            var horizontal = 0f;
            var vertical = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                horizontal -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontal += 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                vertical += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                vertical -= 1;
            }

            // 计算旋转向量
            Vector3 rotation = new Vector3(vertical, 0, horizontal) * (rotationSpeed * Time.deltaTime);

            // 更新物体的旋转
            transform.Rotate(rotation, Space.World);
        }

        // 获取当前位置
        public Vector3 GetStartPos()
        {
            return transform.position;
        }

        // 获取当前缩放
        public Vector3 GetScale()
        {
            return transform.lossyScale;
        }

        // 获取当前旋转
        public Quaternion GetRotation()
        {
            return transform.rotation;
        }

        // 创建一个包含当前状态的备忘录
        internal AppleMemento CreateMemento()
        {
            return new AppleMemento(this);
        }

        // 根据提供的备忘录恢复状态
        internal void Restore(AppleMemento memento)
        {
            transform.position = memento.GetStartPos();
            transform.localScale = memento.GetScale();
            transform.rotation = memento.GetRotation();
        }
    }
}