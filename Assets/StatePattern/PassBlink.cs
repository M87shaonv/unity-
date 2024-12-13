using UnityEngine;

public class PassBlink : TrafficState
{
    private bool On = true;
    private float BlinkTimer = 0;
    private float BlinkInterval = 0.2f;

    public PassBlink()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
    }

    private static void SwitchGreen(Material GreenLight, bool open)
    {
        Color color = open ? Color.green : Color.black;
        GreenLight.SetColor(EmissionColor, color);
    }

    public override void ContinuousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Wait());
        }
        if (Time.time > BlinkTimer+BlinkInterval)
        {
            On = !On;
            BlinkTimer = Time.time;
            SwitchGreen(GreenLight,On);
        }
    }
}