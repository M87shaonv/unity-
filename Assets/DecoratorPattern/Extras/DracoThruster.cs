namespace DecoratorPattern.Extras
{
    // 具体的装饰器类 DracoThruster 继承自 _CarExtras 类，用来为汽车添加 Draco 推进器
    public class DracoThruster : _CarExtras
    {
        public DracoThruster(_Car prevCarPart, int howMany) : base(prevCarPart, howMany) { }

        public override string GetDescription()
        {
            return $"{prevCarPart.GetDescription()}, {howMany} Draco Thruster";
        }

        public override float Cost()
        {
            return (PriceList.dracoThruster * howMany) + prevCarPart.Cost();
        }
    }
}