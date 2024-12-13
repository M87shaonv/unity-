namespace FacadePattern
{
    //外观角色，它为客户端提供了一个简化的接口来生成随机数
    public class RandomNumberFacade
    {
        private static IRandomNumberGenerator rng;

        static RandomNumberFacade()
        {
            //可以选择不同的随机数生成器
            rng = new RandomNumbersUnity();
            //rng = new RandomNumbersSystem();
        }

        // 初始化随机数生成器的种子
        public static void InitSeed(int seed)
        {
            rng.InitSeed(seed);
        }

        // 获取0到1之间的随机浮点数
        public static float GetRandom01()
        {
            return rng.GetRandom01();
        }

        // 获取指定范围[min, max]内的随机浮点数
        public static float GetRandom(float min, float max)
        {
            return rng.GetRandom(min, max);
        }

        // 获取指定范围[min, max)内的随机整数
        public static int GetRandom(int min, int max)
        {
            return rng.GetRandom(min, max);
        }
    }
}