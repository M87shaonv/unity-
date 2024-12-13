using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool.UnityNative
{
// 使用Unity的原生对象池系统
    public class BulletObjectPoolUnity : ObjectPoolBase
    {
        // 子弹预制件，用来实例化新的子弹
        public MoveBulletUnity bulletPrefab;

        // Unity的原生对象池
        private ObjectPool<MoveBulletUnity> allBullets;

        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("需要子弹预制件的引用");
            }

            // 创建一个新的对象池
            allBullets = new ObjectPool<MoveBulletUnity>(
                CreatePooledItem, // 创建池中对象的回调函数
                OnTakeFromPool, // 从池中取出对象时的回调函数
                OnReturnedToPool, // 将对象返回到池中时的回调函数
                OnDestroyPoolObject, // 当池达到容量并有对象被返回时销毁对象的回调函数
                true, // 是否启用集合检查（防止重复释放）
                INITIAL_POOL_SIZE, // 初始池大小
                MAX_POOL_SIZE); // 最大池大小
        }

        private void Update()
        {
            // 调试信息：显示当前池状态
            Debug.Log($"In pool: {allBullets.CountAll}, Active: {allBullets.CountActive}, Inactive: {allBullets.CountInactive}");

            // 按下K键清空对象池
            if (Input.GetKeyDown(KeyCode.K))
            {
                allBullets.Clear(); // 清空对象池而不是Dispose()，因为Dispose()会完全摧毁池子。
            }
        }

        // 创建新项并添加到池中
        private MoveBulletUnity CreatePooledItem()
        {
            GameObject newBullet = Instantiate(bulletPrefab.gameObject, transform);
            var moveBulletScript = newBullet.GetComponent<MoveBulletUnity>();
            moveBulletScript.objectPool = allBullets; // 设置子弹的对象池引用以便在子弹死亡时返回池中
            return moveBulletScript;
        }

        // 当从池中获取对象时调用
        private void OnTakeFromPool(MoveBulletUnity bullet)
        {
            bullet.gameObject.SetActive(true); // 激活子弹
        }

        // 当对象被返回到池中时调用
        private void OnReturnedToPool(MoveBulletUnity bullet)
        {
            bullet.gameObject.SetActive(false); // 停用子弹
        }

        // 如果池容量已满，则任何返回的对象将被销毁
        private void OnDestroyPoolObject(MoveBulletUnity bullet)
        {
            Debug.Log("销毁池化对象");
            Destroy(bullet.gameObject); // 销毁子弹
        }

        // 从池中获取一个子弹
        public GameObject GetBullet()
        {
            // 从池中获取一个实例。如果池为空，则创建一个新实例
            return allBullets.Get().gameObject;
        }
    }
}