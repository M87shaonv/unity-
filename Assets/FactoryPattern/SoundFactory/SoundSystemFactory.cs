namespace FactoryPattern.SoundFactory
{
// SoundSystemFactory 类负责创建具体的声音系统对象。
    public class SoundSystemFactory
    {
        // SoundSystemType 枚举定义了可以创建的不同类型的声音系统。
        public enum SoundSystemType
        {
            SoundSoftware, // 软件声音系统
            SoundHardware, // 硬件声音系统
            SoundSomethingElse // 其他类型的声音系统
        }

        // CreateSoundSystem 是一个静态方法，它根据提供的类型参数返回一个新的声音系统实例。
        public static ISoundSystem CreateSoundSystem(SoundSystemType type)
        {
            ISoundSystem soundSystem = null; // 初始化为空

            // 根据传入的类型参数选择并创建相应的声音系统实例。
            switch (type)
            {
                case SoundSystemType.SoundSoftware:
                    soundSystem = new SoundSystemSoftware(); // 如果是软件声音系统，则创建该类的新实例
                    break;
                case SoundSystemType.SoundHardware:
                    soundSystem = new SoundSystemHardware(); // 如果是硬件声音系统，则创建该类的新实例
                    break;
                case SoundSystemType.SoundSomethingElse:
                    soundSystem = new SoundSystemOther(); // 如果是其他类型的声音系统，则创建该类的新实例
                    break;
                default:
                    // 如果类型不匹配任何预定义的选项，则返回 null。
                    // 这种情况下，可能需要抛出异常或处理错误情况。
                    break;
            }

            return soundSystem; // 返回创建的声音系统实例
        }
    }
}