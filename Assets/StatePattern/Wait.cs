using UnityEngine;

public class Wait : TrafficState
{
    public Wait()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor(EmissionColor, Color.black);
        YellowLight.SetColor(EmissionColor, Color.yellow);
        RedLight.SetColor(EmissionColor, Color.black);
    }
    public override void ContinuousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Stop());
        }
    }
}