namespace DecoratorPattern
{
    public class Roadster : _Car
    {
        public Roadster()
        {
            description = "Roadster";
        }

        public override string GetDescription()
        {
            return description;
        }

        public override float Cost()
        {
            return PriceList.roadster;
        }
    }
}