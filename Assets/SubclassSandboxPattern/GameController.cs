using UnityEngine;

namespace SubclassSandboxPattern
{
    public class GameController : MonoBehaviour
    {
        private SkyLaunch skyLaunch;
        private SpeedLaunch speedLaunch;

        private void Start()
        {
            skyLaunch = new SkyLaunch();
            speedLaunch = new SpeedLaunch();
        }

        private void Update() //可以结合状态模式来控制超级能力是否可以使用
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skyLaunch.Activate();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                speedLaunch.Activate();
            }
        }
    }
}