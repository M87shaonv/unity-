using UnityEngine;

namespace ComponentPattern
{
    public class JumpComponent : MonoBehaviour
    {
        public float JumpVelocity = 1f;
        public Rigidbody rb;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            rb.velocity = Vector3.up * JumpVelocity;
        }
    }
}