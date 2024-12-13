using UnityEngine;

namespace FacadePattern
{
    public class RandomNumbersUnity : IRandomNumberGenerator
    {
        public void InitSeed(int seed)
        {
            Random.InitState(seed);
        }

        public float GetRandom01()
        {
            return Random.Range(0f, 1f);
        }

        public float GetRandom(float min, float max)
        {
            return Random.Range(min, max);
        }

        public int GetRandom(int min, int max)
        {
            return Random.Range(min, max);
        }
    }
}