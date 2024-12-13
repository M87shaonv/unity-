using UnityEngine;

namespace FacadePattern
{
    //通过 RandomNumberFacade 类来获取随机数，而不需要直接与具体的随机数生成器交互
    public class RandomNumbersController : MonoBehaviour
    {
        private void Start()
        {
            // 初始化随机数生成器的种子
            RandomNumberFacade.InitSeed(0);

            Debug.Log("Float: 0 -> 1");

            // 打印5个0到1之间的随机浮点数
            for (var i = 0; i < 5; i++)
            {
                Debug.Log(RandomNumberFacade.GetRandom01());
            }

            Debug.Log("Float: -1 -> 2");

            // 打印10个-1到2之间的随机浮点数
            for (var i = 0; i < 10; i++)
            {
                Debug.Log(RandomNumberFacade.GetRandom(-1f, 2f));
            }

            Debug.Log("Integer: -10 -> 20");

            // 打印10个-10到20之间的随机整数
            for (var i = 0; i < 10; i++)
            {
                Debug.Log(RandomNumberFacade.GetRandom(-10, 21));
            }
        }
    }
}