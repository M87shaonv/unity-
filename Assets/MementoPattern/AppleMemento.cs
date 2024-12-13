using UnityEngine;

namespace MementoPattern
{
// 作为Apple对象状态的快照，保存了特定时刻的位置、缩放和旋转
    internal class AppleMemento
    {
        private readonly Vector3 _startPos;
        private readonly Vector3 _scale;
        private readonly Quaternion _rotation;

        //接收一个Apple对象并保存它的状态
        public AppleMemento(Apple apple)
        {
            _startPos = apple.GetStartPos();
            _scale = apple.GetScale();
            _rotation = apple.GetRotation();
        }


        // 获取保存的位置
        public Vector3 GetStartPos()
        {
            return _startPos;
        }


        // 获取保存的缩放
        public Vector3 GetScale()
        {
            return _scale;
        }


        // 获取保存的旋转
        public Quaternion GetRotation()
        {
            return _rotation;
        }
    }
}