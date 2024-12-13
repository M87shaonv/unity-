using UnityEngine;

namespace DecouplingPatterns.EventQueue
{
    public class Holder : MonoBehaviour, IHolder
    {
        public virtual void ExecuteEvent(Vector3 targetPos) { }
    }
}