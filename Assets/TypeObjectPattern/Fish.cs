using UnityEngine;

namespace TypeObjectController
{
    public class Fish : Animal
    {
        public Fish(string name, bool canFly) : base(name, canFly) { }

        public override void Talk()
        {
            string canFlyString = flyingType.CanIFly() ? "can" : "can't";

            Debug.Log($"Hello this is {name}, I'm a fish, and I {canFlyString} fly!");
        }
    }
}