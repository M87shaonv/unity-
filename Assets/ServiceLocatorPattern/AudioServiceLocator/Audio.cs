namespace ServiceLocatorPatterns.AudioServiceLocator
{
    // 定义了一个抽象类 Audio，规定所有音频服务必须实现的方法
    public abstract class Audio
    {
        public abstract void PlaySound(int soundID);
        public abstract void StopSound(int soundID);
        public abstract void StopAllSounds();
    }
}