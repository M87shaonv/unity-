using UnityEngine;

namespace ServiceLocatorPatterns.AnotherImplementation
{
    public class SecondService : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Unregister(this);
        }

        public void SimpleMethod()
        {
            Debug.Log("Hey, this is just a simple method from " + nameof(SecondService));
        }
    }
}