using DecoratorPattern.Extras;
using UnityEngine;

namespace DecoratorPattern
{
// 装饰者模式控制器，管理订单逻辑。
    public class OrderSystemController : MonoBehaviour
    {
        private void Start()
        {
            // Order 1: 为 Roadster 添加 Draco 推进器
            _Car roadster = new Roadster(); // 创建基础 Roadster 实例
            roadster = new DracoThruster(roadster, 5); // 为 Roadster 添加 Draco 推进器

            Debug.Log($"You ordered: {roadster.GetDescription()} and have to pay ${roadster.Cost()}");

            // Order 2: 为 Cybertruck 添加 Draco 推进器和弹射座椅
            _Car cybertruck = new Cybertruck(); // 创建基础 Cybertruck 实例
            cybertruck = new DracoThruster(cybertruck, 2); // 为 Cybertruck 添加 Draco 推进器
            cybertruck = new EjectionSeat(cybertruck, 1); // 再为 Cybertruck 添加弹射座椅

            Debug.Log($"You ordered: {cybertruck.GetDescription()} and have to pay ${cybertruck.Cost()}");

            // Order 3: 订购 Model S 没有添加任何额外配件
            _Car modelS = new ModelS(); // 创建基础 Model S 实例

            Debug.Log($"You ordered: {modelS.GetDescription()} and have to pay ${modelS.Cost()}");

            // 模拟一段时间后，某些价格发生了变化。
            PriceList.dracoThruster -= 20;
            PriceList.cybertruck -= 100f;
            PriceList.modelS += 30f;

            Debug.Log("Price changes!");

            // 打印出更新后的订单价格
            Debug.Log($"You ordered: {roadster.GetDescription()} and have to pay ${roadster.Cost()}");
            Debug.Log($"You ordered: {cybertruck.GetDescription()} and have to pay ${cybertruck.Cost()}");
            Debug.Log($"You ordered: {modelS.GetDescription()} and have to pay ${modelS.Cost()}");
        }
    }
}