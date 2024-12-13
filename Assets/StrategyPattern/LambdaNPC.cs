using System;
using UnityEngine;

namespace StrategyPattern
{
// LambdaNPC类，允许通过Lambda表达式设置采样策略
    public class LambdaNPC
    {
        private Func<Vector3, Vector3> _sampleStrategy; // 采样策略

        // 设置LambdaNPC的采样策略
        public void SetSampleStrategy(Func<Vector3, Vector3> sampleStrategy)
        {
            _sampleStrategy = sampleStrategy;
        }

        // 应用采样策略到指定的位置上
        public Vector3 SamplePos(Vector3 pos)
        {
            return _sampleStrategy(pos);
        }
    }
}