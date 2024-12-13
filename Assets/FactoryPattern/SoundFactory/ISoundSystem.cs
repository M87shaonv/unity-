namespace FactoryPattern.SoundFactory
{
// 定义 ISoundSystem 接口，声明了所有具体声音系统必须实现的方法。
    public interface ISoundSystem
    {
        bool PlaySound(int soundId);
        bool StopSound(int soundId);
    }
}