using UnityEngine;

namespace TypeObjectController
{
    public class TypeObjectController : MonoBehaviour
    {
        private void Start()
        {
            // 创建各种动物实例，并设置它们是否能飞。
            Bird ostrich = new Bird("ostrich", canFly: false);
            Bird pigeon = new Bird("pigeon", canFly: true);
            Mammal rat = new Mammal("rat", canFly: false);
            Mammal bat = new Mammal("bat", canFly: true);
            Fish flyingFish = new Fish("flying fish", canFly: true);
            Fish goldFish = new Fish("goldfish", canFly: false);

            // 调用 Talk 方法来输出每种动物是否能飞的信息。
            ostrich.Talk();
            pigeon.Talk();
            rat.Talk();
            bat.Talk();
            flyingFish.Talk();
            goldFish.Talk();
        }
    }
}