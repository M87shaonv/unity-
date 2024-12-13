using UnityEngine;

public class Pass : TrafficState
{
    public Pass()
    {
        Duration = 2;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor(EmissionColor, Color.green);
        YellowLight.SetColor(EmissionColor, Color.black);
        RedLight.SetColor(EmissionColor, Color.black);
    }
    public override void ContinuousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new PassBlink());
        }
    }
}