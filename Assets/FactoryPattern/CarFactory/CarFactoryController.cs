using System.Collections.Generic;
using DecoratorPattern;
using UnityEngine;

namespace FactoryPattern.CarFactory
{
    // 展示工厂模式和装饰者模式的结合使用，用于创建不同配置的汽车对象。
    public class CarFactoryController : MonoBehaviour
    {
        // Start 方法是 Unity 的生命周期方法之一，在场景加载并初始化后立即调用。
        private void Start()
        {
            // 创建两个不同的工厂实例，分别代表美国工厂和中国工厂。
            _CarFactory US_Factory = new USFactory(); // 美国工厂实例
            _CarFactory China_Factory = new ChinaFactory(); // 中国工厂实例

            // 使用美国工厂制造 Model S 型号的汽车，并添加 EjectionSeat 配件。
            _Car order1 = US_Factory.ManufactureCar(
                new CarInfo(CarModels.ModelS, CarExtras.EjectionSeat, 1));
            FinalizeOrder(order1); // 处理完成的订单

            // 使用中国工厂制造 Cybertruck 型号的汽车，并添加 DracoThruster 配件。
            _Car order2 = China_Factory.ManufactureCar(
                new CarInfo(CarModels.Cybertruck, CarExtras.DracoThruster, 1));
            FinalizeOrder(order2); // 处理完成的订单

            // 再次使用美国工厂制造 Roadster 型号的汽车，并添加多个DracoThruster配件
            _Car order3 = US_Factory.ManufactureCar(new CarInfo(CarModels.Roadster, CarExtras.DracoThruster, 2));
            FinalizeOrder(order3); // 处理完成的订单
        }

        // FinalizeOrder 方法用于处理已完成的订单，打印出汽车描述和价格信息
        private void FinalizeOrder(_Car finishedCar)
        {
            Debug.Log(finishedCar == null // 如果成品车为空，则表示无法制造订单
                ? $"Sorry but we can't manufacture your order, please try again!" // 输出错误信息
                : $"Your order: {finishedCar.GetDescription()} is ready for delivery as soon as you pay ${finishedCar.Cost()}"); // 输出汽车描述和需要支付的金额
        }
    }

    public struct CarInfo
    {
        public CarModels Model;
        public List<CarExtra> Extras;

        public CarInfo(CarModels model, List<CarExtra> extras)
        {
            Model = model;
            Extras = extras;
        }

        public CarInfo(CarModels model, CarExtras extras, int number)
        {
            Model = model;
            Extras = new List<CarExtra> { new() { Extra = extras, Number = number, }, };
        }
    }

    public struct CarExtra
    {
        public CarExtras Extra;
        public int Number;

        public CarExtra(CarExtras extra, int number)
        {
            Extra = extra;
            Number = number;
        }
    }

    // CarModels 枚举定义了可用的汽车型号
    public enum CarModels
    {
        ModelS,
        Roadster,
        Cybertruck,
    }

    // CarExtras 枚举定义了可选的汽车配件
    public enum CarExtras
    {
        EjectionSeat, // 弹射座椅
        DracoThruster, // 推进器
    }
}