using UnityEngine;

namespace ServiceLocatorPatterns.AudioServiceLocator
{
    // NullAudio 类提供了不执行任何操作的音频服务实现。
    // 这种设计允许系统在缺少有效音频服务时不会崩溃，而是可以优雅地忽略所有的音频请求。
    public class NullAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log("Do nothing - PlaySound");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log("Do nothing - StopSound");
        }

        public override void StopAllSounds()
        {
            Debug.Log("Do nothing - StopAllSounds");
        }
    }
}