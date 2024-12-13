using UnityEngine;

namespace SubclassSandboxPattern
{
    // Superpower 抽象类是所有超级能力的基础
    public abstract class Superpower
    {
        // 子类必须实现这个方法，它表示激活超级能力时的行为
        public abstract void Activate();

        protected void Move(string where)
        {
            Debug.Log($"Moving towards {where}");
        }

        protected void PlaySound(string sound)
        {
            Debug.Log($"Playing sound {sound}");
        }

        protected void SpawnParticles(string particles)
        {
            Debug.Log($"Firing {particles}");
        }
    }
}