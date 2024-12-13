namespace DecoratorPattern.Extras
{
    // 抽象类 _CarExtras 用作所有汽车配件的基础类，它继承自 _Car 类
    // 这个类允许我们创建具体的装饰器来为汽车对象动态地添加行为
    public abstract class _CarExtras : _Car
    {
        protected int howMany; // 配件的数量
        protected _Car prevCarPart; // 被装饰的汽车对象引用

        // 构造函数接收一个要装饰的 _Car 对象以及配件的数量
        public _CarExtras(_Car prevCarPart, int howMany)
        {
            this.prevCarPart = prevCarPart;
            this.howMany = howMany;
        }
    }
}