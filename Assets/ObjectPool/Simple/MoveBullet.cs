namespace ObjectPool.Simple
{
    public class MoveBullet : BulletBase
    {
        private void Update()
        {
            MoveBullet(); // 调用基类的方法移动子弹

            // 如果子弹超出有效距离，则停用它
            if (IsBulletDead())
            {
                gameObject.SetActive(false); // 停用子弹，使其回到对象池中
            }
        }
    }
}