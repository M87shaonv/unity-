using System;
using UnityEngine;

namespace ComponentPattern
{
    public class Player : MonoBehaviour
    {
        private JumpComponent jumpComponent;
        private MoveComponent moveComponent;

        private void Awake()
        {
            jumpComponent = gameObject.AddComponent<JumpComponent>();
            moveComponent = gameObject.AddComponent<MoveComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                jumpComponent.Jump();
            if (Input.GetKey(KeyCode.A))
                moveComponent.Move(false, 1);
            if (Input.GetKey(KeyCode.D))
                moveComponent.Move(true, 1);
        }
    }
}