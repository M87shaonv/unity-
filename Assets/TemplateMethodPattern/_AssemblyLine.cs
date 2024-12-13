using System.Collections.Generic;
using FactoryPattern.CarFactory;
using UnityEngine;

namespace TemplateMethodPattern
{
    // _AssemblyLine 是抽象类，定义了汽车装配的基本框架和步骤。
    public abstract class _AssemblyLine
    {
        // AssembleCar 方法是模板方法，定义了组装汽车的步骤，子类不能覆盖这个方法。
        public void AssembleCar(List<CarExtra> carExtras)
        {
            InitAssemblyProcess(); // 初始化装配过程

            if (!CanManufactureCar()) // 检查是否可以制造汽车
                return;

            GetCarBase(); // 获取汽车底盘
            GetCarBattery(); // 获取电池
            GetCarBody(); // 获取车身

            CoffeeBreak(); // 工人休息时间

            GetWheels(); // 获取轮子
            GetCarExtras(carExtras); // 获取额外配置
        }

        // CoffeeBreak 和 InitAssemblyProcess 是具体方法，实现了所有子类共用的行为。
        protected void CoffeeBreak()
        {
            Debug.Log("Take a coffee break");
        }

        protected void InitAssemblyProcess()
        {
            Debug.Log("Init" + GetType().Name);
        }

        // GetCarExtras 方法根据提供的额外配置列表来获取相应的配件。
        protected void GetCarExtras(List<CarExtra> carExtras)
        {
            if (carExtras == null) // 如果没有额外配置，则输出提示信息
            {
                Debug.Log("This car comes with no extras");
                return;
            }

            foreach (CarExtra extra in carExtras) // 遍历额外配置列表，并分别处理每个配置项
            {
                switch (extra.Extra)
                {
                    case CarExtras.DracoThruster:
                        Debug.Log($"Get {extra.Number} Draco Thruster");
                        break;
                    case CarExtras.EjectionSeat:
                        Debug.Log($"Get {extra.Number} Ejection Seat");
                        break;
                }
            }
        }

        // 抽象方法，由子类实现以提供具体的实现细节。
        protected abstract void GetCarBody();
        protected abstract void GetCarBase();
        protected abstract void GetCarBattery();
        protected abstract void GetWheels();

        // CanManufactureCar 是钩子方法，允许子类决定是否能够制造汽车。
        protected virtual bool CanManufactureCar()
        {
            return true;
        }
    }
}