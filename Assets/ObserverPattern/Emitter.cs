using UnityEngine;

public class Emitter : MonoBehaviour
{

    public GameObject Ball;

    void Start()
    {
        //First time wait 1 second for to the EmitBall method, then call at random intervals of 0.5-1.5 seconds
        InvokeRepeating(nameof(EmitBall), 1f, Random.Range(0.5f, 1.5f));
    }

    void EmitBall()
    {
        GameObject go = Instantiate(Ball);
        go.GetComponent<Rigidbody>().velocity = Vector3.up * 2f;
        if (Radio.Instance.OnEmitEvent != null)//if Radio.Instance.OnEmitEvent is not null
        {
            Radio.Instance.OnEmitEvent(go.transform);
        }
    }
}
