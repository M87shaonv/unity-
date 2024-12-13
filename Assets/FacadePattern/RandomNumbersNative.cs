namespace FacadePattern
{
    public class RandomNumbersNative : IRandomNumberGenerator
    {
        private System.Random rng = new();

        public void InitSeed(int seed)
        {
            rng = new System.Random(seed);
        }

        public float GetRandom01()
        {
            return (float)rng.NextDouble();
        }

        public float GetRandom(float min, float max)
        {
            return (float)((rng.NextDouble() * (max - min)) + min);
        }

        public int GetRandom(int min, int max)
        {
            return rng.Next(min, max);
        }
    }
}