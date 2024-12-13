using UnityEngine;

namespace TypeObjectController
{
    public class Mammal : Animal
    {
        public Mammal(string name, bool canFly) : base(name, canFly) { }

        public override void Talk()
        {
            string canFlyString = flyingType.CanIFly() ? "can" : "can't";

            Debug.Log($"Hello this is {name}, I'm a mammal, and I {canFlyString} fly!");
        }
    }
}