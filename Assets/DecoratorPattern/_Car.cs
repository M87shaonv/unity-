namespace DecoratorPattern
{
    // 抽象类 _Car 是所有具体汽车类的基础，定义了获取描述和计算成本的方法。
    public abstract class _Car
    {
        protected string description; // 存储汽车的描述信息

        // 获取汽车的描述信息，由子类实现。
        public abstract string GetDescription();

        // 计算汽车的成本，由子类实现。
        public abstract float Cost();
    }
}