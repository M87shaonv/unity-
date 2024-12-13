using UnityEngine;

namespace StrategyPattern
{
    public class NPC
    {
        private AbstractNavPlanner _navPlanner;

        // 设置NPC的导航规划器
        public void SetNavPlanner(AbstractNavPlanner navPlanner)
        {
            _navPlanner = navPlanner;
        }

        // 根据当前导航规划器获取从startPos到endPos的导航路径
        public Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return _navPlanner.GetNavPath(startPos, endPos);
        }
    }
}