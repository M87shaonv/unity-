namespace SubclassSandboxPattern
{
    public class SkyLaunch : Superpower
    {
        // 重写父类的 Activate 方法，定义当 SkyLaunch 被激活时的行为。
        public override void Activate()
        {
            PlaySound("Launch Sky sound"); // 播放发射声音
            SpawnParticles("Fly"); // 生成尘埃粒子效果
            Move("sky"); // 移动到天空
        }
    }
}