using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Optimized
{
    // 这个对象池实现更加复杂但性能更好
    public class BulletObjectPoolOptimized : ObjectPoolBase
    {
        // 子弹预制件，用来实例化新的子弹
        public MoveBulletOptimized bulletPrefab;

        // 保存已池化的子弹
        private readonly List<MoveBulletOptimized> bullets = new();

        // 第一个可用的子弹，不用遍历列表查找
        // 创建一个链表，所有未使用的子弹链接在一起
        private MoveBulletOptimized firstAvailable;

        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("需要子弹预制件的引用");
            }

            // 实例化新子弹并放入列表供以后使用
            for (var i = 0; i < INITIAL_POOL_SIZE; i++)
            {
                GenerateBullet();
            }

            // 构建链表
            firstAvailable = bullets[0];

            // 每个子弹指向下一个
            for (var i = 0; i < bullets.Count - 1; i++)
            {
                bullets[i].next = bullets[i + 1];
            }

            // 最后一个子弹终止链表
            bullets[^1].next = null;
        }

        // 生成单个新子弹并放入列表
        private void GenerateBullet()
        {
            MoveBulletOptimized newBullet = Instantiate(bulletPrefab, transform);
            newBullet.gameObject.SetActive(false);
            bullets.Add(newBullet);
            newBullet.objectPool = this; // 设置子弹的对象池引用
        }

        // 子弹被停用时添加到链表中
        public void ConfigureDeactivatedBullet(MoveBulletOptimized deactivatedObj)
        {
            // 将其作为链表的第一个元素，避免检查第一个是否为null
            deactivatedObj.next = firstAvailable;
            firstAvailable = deactivatedObj;
        }

        // 获取一个子弹
        public GameObject GetBullet()
        {
            // 不是遍历列表查找不活动对象，而是直接获取firstAvailable对象
            if (firstAvailable == null)
            {
                // 如果没有更多子弹可用了，我们根据最大池大小决定是否实例化新的子弹
                if (bullets.Count < MAX_POOL_SIZE)
                {
                    GenerateBullet();
                    MoveBulletOptimized lastBullet = bullets[^1];
                    ConfigureDeactivatedBullet(lastBullet);
                }
                else
                {
                    return null;
                }
            }

            // 从链表中移除
            MoveBulletOptimized newBullet = firstAvailable;
            firstAvailable = newBullet.next;

            GameObject newBulletGO = newBullet.gameObject;
            newBulletGO.SetActive(true);

            return newBulletGO;
        }
    }
}