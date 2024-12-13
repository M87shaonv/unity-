using UnityEngine;

namespace TypeObjectController
{
    public class Bird : Animal
    {
        public Bird(string name, bool canFly) : base(name, canFly) { }

        public override void Talk()
        {
            string canFlyString = flyingType.CanIFly() ? "can" : "can't";
            Debug.Log($"Hello this is {name}, I'm a bird, and I {canFlyString} fly!");
        }
    }
}