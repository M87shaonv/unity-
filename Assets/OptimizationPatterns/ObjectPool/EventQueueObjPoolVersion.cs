using System;
using System.Collections;
using System.Collections.Generic;
using DecouplingPatterns.EventQueue;
using UnityEngine;

public class EventQueueObjPoolVersion : MonoBehaviour
{
    public GameObject PosIndicator;
    private MouseInputManager mouseInputManager;
    private Queue<Transform> mDestinationQueue;
    private Transform Destination;
    public float Speed = 1;
    private ObjPool mPool = new();

    private void Awake()
    {
        mouseInputManager = GetComponent<MouseInputManager>();
    }

    private void Start()
    {
        mouseInputManager.OnMouseClick += AddDestination;
        mDestinationQueue = new Queue<Transform>();
    }

    private void OnDestroy()
    {
        mouseInputManager.OnMouseClick -= AddDestination;
    }

    private void AddDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 destination = ray.GetPoint(10);

        var desIndi = (GameObject)mPool.GetObj();
        if (desIndi == null)
        {
            desIndi = Instantiate(PosIndicator);
            mPool.AddObj(desIndi);
        }

        desIndi.transform.position = destination;
        mDestinationQueue.Enqueue(desIndi.transform);
    }

    private void Update()
    {
        if (Destination == null && mDestinationQueue.Count > 0)
        {
            Destination = mDestinationQueue.Dequeue();
        }

        if (Destination != null)
        {
            float distance = Vector3.Distance(transform.position, Destination.position);
            transform.position = Vector3.Lerp(transform.position, Destination.position, Mathf.Clamp01((Time.deltaTime * Speed) / distance));
            if (distance < 0.01f)
            {
                mPool.DisableObj(Destination.gameObject);
                Destination = null;
            }
        }
    }
}