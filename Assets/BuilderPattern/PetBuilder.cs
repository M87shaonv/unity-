using UnityEngine;

namespace BuilderPattern
{
    // PetBuilder 类继承自 ActorBuilder，实现具体宠物的构建逻辑。
    public class PetBuilder : ActorBuilder
    {
        private PetBuilderParam buildParam;

        public PetBuilder(PetBuilderParam buildParam)
        {
            this.buildParam = buildParam;
        }

        public override Component AddAI()
        {
            BaseAI com = AIFactory.CreateAI<PetAI>(gameObject);
            return com;
        }

        public override Component AddBag()
        {
            var com = gameObject.AddComponent<Bag>();
            return com;
        }

        public override bool HasBag()
        {
            return true;
        }

        public override bool HasWeapon()
        {
            return false;
        }

        public override Component AddWeapon()
        {
            throw new System.NotImplementedException();
        }

        public override void SetBaseAttr()
        {
            actor.id = buildParam.id;
        }

        public override GameObject LoadModel()
        {
            gameObject = (GameObject)Object.Instantiate(Resources.Load(buildParam.prefabName));
            gameObject.name = buildParam.id;
            return gameObject;
        }

        // 添加Pet组件，并设置跟随目标
        public override Actor AddActor()
        {
            var com = gameObject.AddComponent<Pet>();
            com.followTransform = buildParam.followTarget;
            return com;
        }
    }
}