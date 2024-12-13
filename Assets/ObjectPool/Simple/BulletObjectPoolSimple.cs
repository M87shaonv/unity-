using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool.Simple
{
// 简单的对象池实现
    public class BulletObjectPoolSimple : ObjectPoolBase
    {
        // 子弹预制件，用来实例化新的子弹
        public MoveBullet bulletPrefab;

        // 保存已池化的子弹对象
        private readonly List<GameObject> bullets = new();

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
        }

        // 生成单个新子弹并将其放入列表
        private void GenerateBullet()
        {
            GameObject newBullet = Instantiate(bulletPrefab.gameObject, transform);
            newBullet.SetActive(false); // 停用子弹，准备放入池中
            bullets.Add(newBullet); // 将子弹添加到池中
        }

        // 从池中获取一个子弹
        public GameObject GetBullet()
        {
            // 尝试找到一个未激活的子弹
            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy) // 检查子弹是否处于非活动状态
                {
                    bullet.SetActive(true); // 激活子弹
                    return bullet; // 返回激活的子弹
                }
            }

            // 如果没有可用的子弹并且池子还没有满，就创建一个新的子弹
            if (bullets.Count < MAX_POOL_SIZE)
            {
                GenerateBullet();

                // 新子弹是列表中的最后一个元素
                GameObject lastBullet = bullets[^1];
                lastBullet.SetActive(true);

                return lastBullet;
            }

            // 如果池子满了或者找不到可用的子弹，返回null
            return null;
        }
    }
}