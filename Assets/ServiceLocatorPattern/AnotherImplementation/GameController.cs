using UnityEngine;

namespace ServiceLocatorPatterns.AnotherImplementation
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            var firstService = ServiceLocator.Resolve<FirstService>();
            var secondService = ServiceLocator.Resolve<SecondService>();
            var thirdService = ServiceLocator.Resolve<ThirdService>();

            if (firstService != null)
            {
                firstService.SayHi();
            }

            if (secondService != null)
            {
                secondService.SimpleMethod();
            }

            if (thirdService != null)
            {
                thirdService.Foo();
            }

            ServiceLocator.Unregister(firstService);
            ServiceLocator.Unregister(secondService);
            ServiceLocator.Unregister(thirdService);
        }
    }
}