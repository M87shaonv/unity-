namespace DecoratorPattern
{
// 价格列表类用于存储车辆基础价格和额外配件的价格。
    public static class PriceList
    {
        // 基础车型价格
        public static float cybertruck = 150f; // Cybertruck 的基础价格
        public static float modelS = 200f; // Model S 的基础价格
        public static float roadster = 350f; // Roadster 的基础价格

        // 额外配件价格
        public static float dracoThruster = 20f; // Draco 推进器的价格
        public static float ejectionSeat = 200f; // 弹射座椅的价格
    }
}