using UnityEngine;

namespace TemplateMethodPattern
{
    public class AssembleModelS : _AssemblyLine
    {
        // 实现抽象方法，提供针对Model S的具体实现。
        protected override void GetCarBase()
        {
            Debug.Log("Get Model S base");
        }

        protected override void GetCarBattery()
        {
            Debug.Log("Get Model S battery");
        }

        protected override void GetCarBody()
        {
            Debug.Log("Get Model S body");
        }

        protected override void GetWheels()
        {
            Debug.Log("Get Model S wheels");
        }
    }
}