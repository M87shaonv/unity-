using UnityEngine;

namespace BuilderPattern
{
// AI 工厂用于创建不同类型的AI组件。
    public class AIFactory
    {
        //可以在此处实现具体的AI创建逻辑。
        public static BaseAI CreateAI<T>(GameObject go) where T : BaseAI
        {
            return go.AddComponent<T>();
        }
    }
}