using UnityEngine;

public class Radio : MonoBehaviour
{

    public delegate void EmitHandler(Transform target);// Define a delegate type for the event
    public EmitHandler OnEmitEvent;// Create a new event with the delegate type
    public static Radio Instance;

    void Awake()
    {
        Instance = this;
    }
}
