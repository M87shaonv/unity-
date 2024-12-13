namespace FacadePattern
{
    public interface IRandomNumberGenerator
    {
        // 初始化随机数生成器的种子
        void InitSeed(int seed);

        // 获取0到1之间的随机浮点数
        float GetRandom01();

        // 获取指定范围[min, max]内的随机浮点数
        float GetRandom(float min, float max);

        // 获取指定范围[min, max)内的随机整数
        int GetRandom(int min, int max);
    }
}