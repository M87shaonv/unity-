namespace ObjectPool
{
    using UnityEngine;

    // 此类作为所有对象池的基类，避免了代码重复。
    // 由于可以调用 Object.Instantiate 并传递预制件 GameObject，因此即使没有 MonoBehaviour 也可以创建可重用的 GameObject 池。
    // 这可以在父类或池管理器 MonoBehaviour 中完成。
    public class ObjectPoolBase : MonoBehaviour
    {
        // 定义当游戏开始时拥有的子弹数量
        protected const int INITIAL_POOL_SIZE = 100;
        protected const int MAX_POOL_SIZE = 1000;
    }
}