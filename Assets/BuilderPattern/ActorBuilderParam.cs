namespace BuilderPattern
{
// 定义了一个抽象类，用于封装所有需要传递给建造者的参数
    public abstract class ActorBuilderParam
    {
        // 每个游戏对象的唯一标识符和预制体名称
        public string id;
        public string prefabName;
    }
}