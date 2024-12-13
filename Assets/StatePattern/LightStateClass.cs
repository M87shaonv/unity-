using UnityEngine;

public class LightStateClass : MonoBehaviour
{

    public GameObject GreenLightObj;
    public GameObject YellowLightObj;
    public GameObject RedLightObj;
    //灯光材质
    private Material GreenLight;
    private Material YellowLight;
    private Material RedLight;
    //当前灯光状态
    private TrafficState TrafficLight;

    void Start()
    {
        GreenLight = GreenLightObj.GetComponent<Renderer>().material;
        YellowLight = YellowLightObj.GetComponent<Renderer>().material;
        RedLight = RedLightObj.GetComponent<Renderer>().material;
        SetState(new Pass());

    }

    void Update()
    {
        TrafficLight.ContinuousStateBehaviour(this, GreenLight, YellowLight, RedLight);
    }

    public void SetState(TrafficState state)
    {
        TrafficLight = state;
        TrafficLight.StateStart(GreenLight, YellowLight, RedLight);
    }
}

public abstract class TrafficState
{
    public float Duration;
    public float Timer;
    public static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");//控制材质自发光颜色属性ID
    public virtual void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        Timer = Time.time;//当前时间
    }
    public abstract void ContinuousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight);
}




