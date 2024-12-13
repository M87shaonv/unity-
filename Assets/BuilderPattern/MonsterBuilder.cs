using UnityEngine;

namespace BuilderPattern
{
// MonsterBuilder 类继承自 ActorBuilder，实现具体怪物的构建逻辑
    public class MonsterBuilder : ActorBuilder
    {
        private MonsterBuilderParam buildParam;

        public MonsterBuilder(MonsterBuilderParam buildParam)
        {
            this.buildParam = buildParam;
        }

        public override Component AddAI()
        {
            BaseAI com = AIFactory.CreateAI<MonsterAI>(gameObject);
            return com;
        }

        public override Component AddWeapon()
        {
            Weapon com = WeaponFactory.CreateWeapon(gameObject, buildParam.weaponId);
            com.weaponId = buildParam.weaponId;
            return com;
        }

        public override bool HasBag()
        {
            return false;
        }

        public override bool HasWeapon()
        {
            return buildParam.weaponId != null;
        }

        public override Component AddBag()
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

        public override Actor AddActor()
        {
            var com = gameObject.AddComponent<Monster>();
            com.hp = buildParam.hp;
            com.mp = buildParam.mp;
            com.maxHp = buildParam.maxHp;
            com.maxMp = buildParam.maxMp;
            return com;
        }

        // 重写Reset方法，允许使用新的参数重新配置建造者
        public override void Reset(ActorBuilderParam buildParam)
        {
            base.Reset(buildParam);
            this.buildParam = (MonsterBuilderParam)buildParam;
        }
    }
}