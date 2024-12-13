using UnityEngine;

namespace FactoryPattern.SoundFactory
{
// SoundFactoryController 类是用于管理声音系统的控制器。
// 它使用工厂方法模式来创建不同类型的音效系统实例。
    public class SoundFactoryController : MonoBehaviour
    {
        private void Start()
        {
            // 创建一个软件实现的声音系统，并播放 ID 为 1 的声音。
            ISoundSystem soundSystemSoftware = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundSoftware);
            soundSystemSoftware.PlaySound(1);

            // 创建一个硬件实现的声音系统，并播放 ID 为 2 的声音。
            ISoundSystem soundSystemHardware = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundHardware);
            soundSystemHardware.PlaySound(2);

            // 创建一个其他类型的声音系统，并播放 ID 为 3 的声音。
            ISoundSystem soundSystemOther = SoundSystemFactory.CreateSoundSystem(SoundSystemFactory.SoundSystemType.SoundSomethingElse);
            soundSystemOther.PlaySound(3);

            // 停止播放所有之前启动的声音。
            soundSystemSoftware.StopSound(1);
            soundSystemHardware.StopSound(2);
            soundSystemOther.StopSound(3);
        }
    }
}