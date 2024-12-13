using UnityEngine;

namespace TemplateMethodPattern
{
    public class AssembleCybertruck : _AssemblyLine
    {
        // 实现抽象方法，提供针对Cybertruck的具体实现。
        protected override void GetCarBase()
        {
            Debug.Log("Get Cybertruck base");
        }

        protected override void GetCarBattery()
        {
            Debug.Log("Get Cybertruck battery");
        }

        protected override void GetCarBody()
        {
            Debug.Log("Get Cybertruck body");
        }

        protected override void GetWheels()
        {
            Debug.Log("Get Cybertruck wheels");
        }

        // 重写 CanManufactureCar 方法，返回 false 表示 Cybertruck 不能被制造。
        protected override bool CanManufactureCar()
        {
            Debug.Log("Sorry but the Cybertruck is still a prototype so we can't manufacture it!");
            return false;
        }
    }
}