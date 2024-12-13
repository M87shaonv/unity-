using UnityEngine;

namespace DecouplingPatterns.EventQueue
{
    public class Dragon : Holder
    {
        public override void ExecuteEvent(Vector3 targetPos)
        {
            Vector3 direction = targetPos - transform.position; // 计算方向向量
            Quaternion targetRotation = Quaternion.LookRotation(direction); // 计算旋转角度
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}