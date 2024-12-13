using UnityEngine;

namespace ObjectPool
{
    public class BulletBase : MonoBehaviour
    {
        private readonly float bulletSpeed = 10f; // 子弹速度
        private readonly float deactivationDistance = 30f; // 子弹失去作用的距离

        // 移动子弹的方法
        protected void MoveBullet()
        {
            transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward); // 按照子弹的速度向前移动
        }

        // 检查子弹是否应该被停用的方法
        protected bool IsBulletDead()
        {
            // 如果子弹离原点（假设枪支位于原点）的距离超过了设定的距离，则认为子弹应被停用
            bool isDead = Vector3.SqrMagnitude(Vector3.zero - transform.position) > deactivationDistance * deactivationDistance;
            return isDead;
        }
    }
}