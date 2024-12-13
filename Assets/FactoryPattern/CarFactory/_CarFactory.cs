using DecoratorPattern;

namespace FactoryPattern.CarFactory
{
    // 抽象工厂类，定义了一个制造汽车的方法
    public abstract class _CarFactory
    {
        // 这个方法是所谓的“工厂方法”，它用于创建特定类型的汽车
        public abstract _Car ManufactureCar(CarInfo carInfo);
    }
}