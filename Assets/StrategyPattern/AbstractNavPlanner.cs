using UnityEngine;

namespace StrategyPattern
{
    // 抽象导航规划器类，所有具体的导航规划器都继承自这个类
    public abstract class AbstractNavPlanner
    {
        // 获得从startPos到endPos的导航路径
        public abstract Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos);
    }
}