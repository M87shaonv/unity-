using System.Collections.Generic;

namespace MementoPattern
{
// 管理多个AppleMemento对象，维护了一个备忘录列表
    public class MementoCaretaker
    {
        private readonly List<AppleMemento> _mementoList = new();

        //添加一个新的备忘录到列表中
        internal void AddMemento(AppleMemento memento)
        {
            _mementoList.Add(memento);
        }

        //根据索引获取备忘录
        internal AppleMemento GetMemento(int index)
        {
            if (index >= 0 && index < _mementoList.Count)
            {
                return _mementoList[index];
            }

            return null;
        }

        //返回备忘录列表中的元素数量
        internal int GetMementoCount()
        {
            return _mementoList.Count;
        }
    }
}