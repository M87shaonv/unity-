namespace ObjectPool.Optimized
{
// 继承自 BulletBase 类，用于优化子弹移动逻辑
    public class MoveBulletOptimized : BulletBase
    {
        // 用于优化对象池性能，创建一个链表结构
        [System.NonSerialized] public MoveBulletOptimized next;

        // 对象池引用，以便在子弹停用时通知对象池
        [System.NonSerialized] public BulletObjectPoolOptimized objectPool;

        private void Update()
        {
            MoveBullet(); // 调用基类方法移动子弹

            // 如果子弹超出有效距离，则停用它
            if (IsBulletDead())
            {
                // 告诉对象池此子弹已被停用
                objectPool.ConfigureDeactivatedBullet(this);

                gameObject.SetActive(false); // 停用子弹的游戏对象
            }
        }
    }
}