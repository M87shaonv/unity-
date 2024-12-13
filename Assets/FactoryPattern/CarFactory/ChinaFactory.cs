using System.Collections.Generic;
using DecoratorPattern;
using DecoratorPattern.Extras;
using UnityEngine;

namespace FactoryPattern.CarFactory
{
    public class ChinaFactory : _CarFactory
    {
        public override _Car ManufactureCar(CarInfo carInfo)
        {
            _Car car = null;

            // 根据传入的型号参数创建相应的汽车实例。
            if (carInfo.Model == CarModels.ModelS)
            {
                car = new ModelS();
            }
            else if (carInfo.Model == CarModels.Roadster)
            {
                car = new Roadster();
            }

            // 注意：Cybertruck 模型在这里没有被处理，所以无法由中国工厂生产！
            if (car == null)
            {
                Debug.Log("Sorry but this factory can't manufacture this model :(");
                return car;
            }

            // 为汽车添加额外配置项。
            foreach (CarExtra carExtra in carInfo.Extras)
            {
                // 根据配置项类型创建相应的装饰器，并将其应用到汽车上。
                if (carExtra.Extra == CarExtras.DracoThruster)
                {
                    car = new DracoThruster(car, carExtra.Number);
                }
                else if (carExtra.Extra == CarExtras.EjectionSeat)
                {
                    car = new EjectionSeat(car, carExtra.Number);
                }
                else
                {
                    Debug.Log("Sorry but this factory can't add this car extra :(");
                }
            }

            return car;
        }
    }
}