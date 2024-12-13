using UnityEngine;

namespace BuilderPattern
{
// 抽象建造者类，定义了构建游戏对象的一般流程。
    public abstract class ActorBuilder
    {
        protected Actor actor; // 游戏中的Actor组件
        protected GameObject gameObject; // 当前正在构建的游戏对象

        // 设置基础属性
        public abstract void SetBaseAttr();

        public abstract Component AddWeapon();

        public abstract Component AddAI();

        public abstract Component AddBag();

        public abstract Actor AddActor();

        public abstract GameObject LoadModel();

        public virtual bool HasBag()
        {
            return false;
        }

        public virtual bool HasWeapon()
        {
            return true;
        }

        // 重置建造者状态
        public virtual void Reset(ActorBuilderParam buildParam)
        {
            actor = null;
        }

        public virtual Component AddOnClickBehaviour()
        {
            var com = gameObject.AddComponent<OnClickBehaviour>();
            return com;
        }

        // 构建完整的游戏对象，包括所有可能的组件
        public Actor ConstructFull()
        {
            GameObject go = LoadModel();
            actor = AddActor();
            SetBaseAttr();

            // 根据钩子方法判断是否添加特定组件
            if (HasWeapon())
            {
                AddWeapon();
            }

            AddAI();
            AddOnClickBehaviour();

            if (HasBag())
            {
                AddBag();
            }

            return actor;
        }

        // 构建最小化的游戏对象，仅包含必要组件。
        public Actor ConstructMinimal()
        {
            GameObject go = LoadModel();
            actor = AddActor();
            SetBaseAttr();
            return actor;
        }
    }
}