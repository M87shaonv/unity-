using UnityEngine;

namespace ServiceLocatorPatterns.AnotherImplementation
{
    public class FirstService : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register(this);
            //ServiceLocator.Register(this);//抛出异常，因为已经注册过了
        }

        private void OnDestroy()
        {
            ServiceLocator.Unregister(this);
        }

        public void SayHi()
        {
            Debug.Log("Hi, this is the " + nameof(FirstService));
        }
    }
}