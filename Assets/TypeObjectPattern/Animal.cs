namespace TypeObjectController
{
    public abstract class Animal
    {
        protected string name;
        protected IFlyingType flyingType;

        protected Animal(string name, bool canFly)
        {
            this.name = name;
            flyingType = canFly ? new ICanFly() : new ICantFly();
        }

        public abstract void Talk();
    }
}