using UnityEngine;

namespace MementoPattern
{
// 提供了一种构建Apple对象的方法
    public class AppleBuilder
    {
        private string prefab;

        /// <summary>
        /// 构造函数，接收预制体名称
        /// </summary>
        /// <param name="prefab">预制体资源</param>
        public AppleBuilder(string prefab)
        {
            this.prefab = prefab;
        }

        // 从资源中加载预制体，并实例化一个新的Apple对象
        public Apple Generate()
        {
            GameObject appleObj = Object.Instantiate(Resources.Load<GameObject>(prefab));
            var apple = appleObj.GetComponent<Apple>();
            return apple;
        }
    }
}