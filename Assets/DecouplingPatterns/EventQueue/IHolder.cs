using UnityEngine;

namespace DecouplingPatterns.EventQueue
{
    public interface IHolder
    {
        public void ExecuteEvent(Vector3 targetPos);
    }
}