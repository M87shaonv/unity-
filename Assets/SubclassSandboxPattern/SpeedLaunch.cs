namespace SubclassSandboxPattern
{
    public class SpeedLaunch : Superpower
    {
        public override void Activate()
        {
            PlaySound("Launch Speed Launch");
            SpawnParticles("dust");
            Move("quickly");
        }
    }
}