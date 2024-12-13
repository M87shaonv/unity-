using UnityEngine;

namespace ServiceLocatorPatterns.AudioServiceLocator
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            // 创建一个 ConsoleAudio 实例，并通过 Locator 注册该实例作为当前游戏的音频服务提供者。
            // 如果希望禁用音频功能，可以传递 null 给 Provide 方法。
            var consoleAudio = new ConsoleAudio();
            Locator.Provide(consoleAudio);
            //Locator.Provide(null); // 用于测试 NullAudio 的行为
        }

        private void Update()
        {
            // 从 Locator 获取当前的音频服务提供者。
            Audio locatorAudio = Locator.GetAudio();

            if (Input.GetKeyDown(KeyCode.P))
            {
                locatorAudio.PlaySound(23);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                locatorAudio.StopSound(23);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                locatorAudio.StopAllSounds();
            }
        }
    }
}