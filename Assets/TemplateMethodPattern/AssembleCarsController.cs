using System.Collections.Generic;
using FactoryPattern.CarFactory;
using UnityEngine;

namespace TemplateMethodPattern
{
    // AssembleCarsController 是控制类，它负责初始化装配线并开始组装不同类型的汽车。
    public class AssembleCarsController : MonoBehaviour
    {
        private void Start()
        {
            // 初始化两条装配线：一条用于Cybertruck，另一条用于Model S
            var cybertruck = new AssembleCybertruck();
            var modelS = new AssembleModelS();

            // 根据订单组装汽车，包括选择特定的额外配置（CarExtras）
            cybertruck.AssembleCar(new List<CarExtra>() { new(CarExtras.DracoThruster, 1), new(CarExtras.EjectionSeat, 1), });
            modelS.AssembleCar(new List<CarExtra>() { new(CarExtras.DracoThruster, 1), new(CarExtras.EjectionSeat, 2), });

            // 组装没有额外配置的Model S
            modelS.AssembleCar(null);
        }
    }
}