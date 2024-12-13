using UnityEngine;

public class Stop : TrafficState
{
    public Stop()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor(EmissionColor, Color.black);
        YellowLight.SetColor(EmissionColor, Color.black);
        RedLight.SetColor(EmissionColor, Color.red);
    }
    public override void ContinuousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Pass());
        }
    }
}