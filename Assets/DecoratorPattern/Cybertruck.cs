namespace DecoratorPattern
{
    public class Cybertruck : _Car
    {
        public Cybertruck()
        {
            description = "Cybertruck";
        }

        public override string GetDescription()
        {
            return description;
        }

        public override float Cost()
        {
            return PriceList.cybertruck;
        }
    }
}