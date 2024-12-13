using UnityEngine;

namespace ServiceLocatorPatterns.AudioServiceLocator
{
    public class ConsoleAudio : Audio
    {
        // 在控制台输出一条信息表示开始播放指定 ID 的声音。
        public override void PlaySound(int soundID)
        {
            Debug.Log($"Sound {soundID} has started");
        }

        // 在控制台输出一条信息表示停止播放指定 ID 的声音。
        public override void StopSound(int soundID)
        {
            Debug.Log($"Sound {soundID} has stopped");
        }

        // 在控制台输出一条信息表示停止所有正在播放的声音。
        public override void StopAllSounds()
        {
            Debug.Log("All sounds have stopped");
        }
    }
}