using UnityEngine.Pool;

namespace ObjectPool.UnityNative
{
    public class MoveBulletUnity : BulletBase
    {
        // 对象池引用，用于停用子弹时将其返回池中
        public IObjectPool<MoveBulletUnity> objectPool;

        private void Update()
        {
            MoveBullet(); // 移动子弹

            // 如果子弹超出有效距离，则停用它
            if (IsBulletDead())
            {
                // 返回实例到池中
                objectPool.Release(this);
            }
        }
    }
}