using UnityEngine;

namespace BuilderPattern
{
    // PetBuilderParam 类继承自 ActorBuilderParam，为宠物提供特定参数
    public class PetBuilderParam : ActorBuilderParam
    {
        // 宠物跟随的目标Transform
        public Transform followTarget;

        public PetBuilderParam(string id, string prefabName, Transform followTarget = null)
        {
            this.id = id;
            this.prefabName = prefabName;
            this.followTarget = followTarget;
        }
    }
}