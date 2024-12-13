using System.Collections;
using System.Collections.Generic;
using ObjectPool.UnityNative;
using UnityEngine;

namespace ObjectPool
{
    public class GunController : MonoBehaviour
    {
        // 在层次结构中激活你想要使用的对象池，并将其拖到未注释的槽位中
        // 可以选择三种不同类型的子弹池：
        //public BulletObjectPoolSimple bulletPool; // 最简单的对象池
        //public BulletObjectPoolOptimized bulletPool; // 优化后的对象池
        public BulletObjectPoolUnity bulletPool; // Unity原生的对象池,性能最高

        // 私有成员变量
        private readonly float rotationSpeed = 60f; // 枪支旋转速度
        private float fireTimer; // 记录自上次开火以来的时间
        private readonly float fireInterval = 0.1f; // 开火间隔时间
        private List<Transform> firePoints;

        private void Start()
        {
            fireTimer = Mathf.Infinity; // 初始设置为无穷大，确保首次触发射击时不会受到冷却时间影响
            firePoints = new List<Transform>(); // 初始化枪口位置列表
            if (bulletPool == null)
            {
                Debug.LogError("需要引用对象池"); // 如果没有分配子弹池，则记录错误信息
            }

            foreach (Transform child in transform)
            {
                firePoints.Add(child); // 记录枪口位置
            }
        }

// 协程用于延迟发射子弹
        private IEnumerator DelayedFire(float delay)
        {
            yield return new WaitForSeconds(delay);
            // 这里可以放置任何需要延迟执行的代码
        }

        private void Update()
        {
            // 使用A键和D键旋转枪支
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space) && fireTimer > fireInterval)
            {
                fireTimer = 0f; // 重置开火计时器
                var numberOfBullets = 10; // 发射子弹的数量
                var spreadAngle = 20f; // 散射角度范围（度）
                var bulletSpacing = 0.1f; // 子弹之间的前后距离（秒）

                for (var i = 0; i < numberOfBullets; i++) // 循环发射子弹
                {
                    GameObject newBullet = bulletPool.GetBullet(); // 从对象池获取子弹

                    if (newBullet != null)
                    {
                        // 计算散射角度（在 -spreadAngle/2 到 +spreadAngle/2 的范围内随机选择）
                        float angleOffset = Random.Range(-spreadAngle / 2, spreadAngle / 2);
                        Transform firePoint = firePoints[Random.Range(0, firePoints.Count)]; // 随机选择枪口位置

                        // 获取当前子弹的方向并应用角度偏移
                        Vector3 shootDirection = firePoint.forward;
                        Quaternion rotationOffset = Quaternion.Euler(0, angleOffset, 0);
                        shootDirection = rotationOffset * shootDirection;

                        // 设置子弹的位置为玩家位置，并稍微向前移动以避免与玩家模型碰撞
                        Vector3 spawnPosition = firePoint.position + (firePoint.forward * (i * bulletSpacing));

                        // 初始化子弹（假设有一个方法可以设置子弹的初始位置和方向）
                        newBullet.transform.position = spawnPosition;
                        newBullet.transform.rotation = rotationOffset * firePoint.rotation;

                        // 如果有特定的方法来启动子弹，比如 SetVelocity 或类似的方法，可以在这里调用
                        // 例如：newBullet.GetComponent<Bullet>().SetVelocity(shootDirection);

                        // 延迟发射下一颗子弹
                        StartCoroutine(DelayedFire(i * bulletSpacing));
                    }
                    else
                    {
                        Debug.Log("无法找到新子弹"); // 如果没有可用子弹，记录日志信息
                    }
                }
            }

            // 更新自上一次开火以来经过的时间
            fireTimer += Time.deltaTime;
        }
    }
}