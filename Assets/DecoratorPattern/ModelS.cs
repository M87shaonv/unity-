namespace DecoratorPattern
{
    public class ModelS : _Car
    {
        public ModelS()
        {
            description = "Model S";
        }

        public override string GetDescription()
        {
            return description;
        }

        public override float Cost()
        {
            return PriceList.modelS;
        }
    }
}