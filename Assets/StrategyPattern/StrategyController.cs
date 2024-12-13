using UnityEngine;

namespace StrategyPattern
{
public class StrategyController : MonoBehaviour
    {
        private void Start()
        {
            // 定义起始位置和结束位置
            Vector3 startPos = transform.position;
            var endPos = new Vector3(10, 0, 10);

            // 创建一个飞行NPC，并设置其导航规划器为飞行路径规划器
            var theFlyNPC = new NPC();
            theFlyNPC.SetNavPlanner(new FlyNavPlanner());
            foreach (Vector3 navPath in theFlyNPC.GetNavPath(startPos, endPos))
            {
                Debug.Log($"flyNpc规划的路径是:{navPath}");
            }

            // 创建一个游泳NPC，并设置其导航规划器为游泳路径规划器
            var theSwimNPC = new NPC();
            theSwimNPC.SetNavPlanner(new SwimNavPlanner());
            foreach (Vector3 navPath in theSwimNPC.GetNavPath(startPos, endPos))
            {
                Debug.Log($"swimNpc规划的路径是:{navPath}");
            }

            // 创建一个跳跃NPC，并设置其导航规划器为跳跃路径规划器
            var theJumpNPC = new NPC();
            theJumpNPC.SetNavPlanner(new JumpNavPlanner());
            foreach (Vector3 navPath in theJumpNPC.GetNavPath(startPos, endPos))
            {
                Debug.Log($"jumpNpc规划的路径是:{navPath}");
            }

            // 创建一个直线移动的NPC，并设置其导航规划器为直线路径规划器
            var theStraightNPC = new NPC();
            theStraightNPC.SetNavPlanner(new StraightNavPlanner());
            foreach (Vector3 navPath in theStraightNPC.GetNavPath(startPos, endPos))
            {
                Debug.Log($"straightNpc规划的路径是:{navPath}");
            }

            var pos = new Vector3(1, 5, 1);
            // 创建一个特定于游泳的NPC，并为其设置特殊的采样策略
            var swimNPC2 = new LambdaNPC();
            swimNPC2.SetSampleStrategy(_ => new Vector3(pos.x, 0, pos.z)); // 强制Y轴为0，模拟游泳行为
            // 测试游泳NPC的采样策略
            pos = new Vector3(1, 5, 1);
            Debug.Log($"swimNPC2 samplePos {pos}->{swimNPC2.SamplePos(pos)}");
            pos = new Vector3(2, 5, 2);
            Debug.Log($"swimNPC2 samplePos {pos}->{swimNPC2.SamplePos(pos)}");
        }
    }
}