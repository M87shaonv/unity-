using UnityEngine;

namespace BuilderPattern
{
    // Pet 类继承自 Actor，增加了跟随目标的特性。
    public class Pet : Actor
    {
        public Transform followTransform; // 宠物要跟随的目标

        // 宠物特有的初始化或更新逻辑可以写在这里
    }
}