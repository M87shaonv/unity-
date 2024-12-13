using UnityEngine;

namespace StrategyPattern
{
    public class StraightNavPlanner : AbstractNavPlanner
    {
        public override Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            // 返回一条简单的直线路径，仅包含起始点和终点
            return new[] { startPos, endPos, };
        }
    }
}