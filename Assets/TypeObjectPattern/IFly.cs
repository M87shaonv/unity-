namespace TypeObjectController
{
    //实现了 IFlyingType 接口的具体类，分别代表了能飞和不能飞的类型
    public class ICanFly : IFlyingType
    {
        public bool CanIFly()
        {
            return true;
        }
    }

    public class ICantFly : IFlyingType
    {
        public bool CanIFly()
        {
            return false;
        }
    }
}