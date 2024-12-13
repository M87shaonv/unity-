namespace TypeObjectController
{
    //定义了一个可以飞行的类型的契约，任何实现了此接口的类都需要提供 CanIFly() 方法的实现，该方法返回布尔值以表示该类型是否能够飞行
    public interface IFlyingType
    {
        bool CanIFly();
    }
}