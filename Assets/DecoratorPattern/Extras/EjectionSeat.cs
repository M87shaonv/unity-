namespace DecoratorPattern.Extras
{
    // 具体的装饰器类 EjectionSeat 继承自 _CarExtras 类，用来为汽车添加弹射座椅。
    public class EjectionSeat : _CarExtras
    {
        public EjectionSeat(_Car prevCarPart, int howMany) : base(prevCarPart, howMany) { }

        public override string GetDescription()
        {
            return $"{prevCarPart.GetDescription()}, {howMany} Ejection Seat";
        }

        public override float Cost()
        {
            return (PriceList.ejectionSeat * howMany) + prevCarPart.Cost();
        }
    }
}