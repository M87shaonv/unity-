using UnityEngine;

namespace FactoryPattern.SoundFactory
{
    public class SoundSystemSoftware : ISoundSystem
    {
        public bool PlaySound(int soundId)
        {
            Debug.Log($"Played the sound with id {soundId} on the software");
            return true; // 假设总是成功播放声音。
        }

        public bool StopSound(int soundId)
        {
            Debug.Log($"Stopped the sound with id {soundId} on the software");
            return true; // 假设总是成功停止播放声音。
        }
    }
}