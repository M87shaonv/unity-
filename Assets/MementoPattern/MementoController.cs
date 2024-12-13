using UnityEngine;

namespace MementoPattern
{
    public class MementoController : MonoBehaviour
    {
        public Apple apple;
        private MementoCaretaker _mc;

        private void Start()
        {
            _mc = new MementoCaretaker();
            var builder = new AppleBuilder("Apple"); // 创建AppleBuilder实例
            apple = builder.Generate(); // 使用AppleBuilder生成Apple实例
            _mc.AddMemento(apple.CreateMemento()); // 保存Apple的初始状态
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _mc.AddMemento(apple.CreateMemento());
                Debug.Log($"存储成功,当前队列数量{_mc.GetMementoCount()}");
            }

            int offset = -1;
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                offset = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                offset = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                offset = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                offset = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                offset = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                offset = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                offset = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                offset = 7;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                offset = 8;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                offset = 9;
            }

            // 如果设置了有效的offset值，则尝试回退到指定的历史状态
            if (offset == -1) return;
            int idx = _mc.GetMementoCount() - offset;
            AppleMemento memento = _mc.GetMemento(idx - 1);
            if (null != memento)
            {
                Debug.Log($"后退{offset}步到到{idx}");
                apple.Restore(memento); // 恢复到指定的memento状态
            }
            else
            {
                Debug.LogError("No Memento");
            }
        }
    }
}