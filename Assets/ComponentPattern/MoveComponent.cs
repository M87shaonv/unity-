using UnityEngine;

namespace ComponentPattern
{
    public class MoveComponent : MonoBehaviour
    {
        public void Move(bool isRight, float speed)
        {
            float direction = isRight ? 1f : -1f;
            transform.Translate(Vector3.right * (direction * speed * Time.deltaTime), Space.World);
        }
    }
}