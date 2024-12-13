namespace BuilderPattern
{
// MonsterBuilderParam 类继承自 ActorBuilderParam，为怪物提供特定参数
    public class MonsterBuilderParam : ActorBuilderParam
    {
        public float hp;
        public float maxHp;
        public float mp;
        public float maxMp;
        public string weaponId;

        public MonsterBuilderParam(string id, string prefabName, float hp, float maxHp, float mp, float maxMp, string weaponId = null)
        {
            this.id = id;
            this.prefabName = prefabName;
            this.hp = hp;
            this.maxHp = maxHp;
            this.mp = mp;
            this.maxMp = maxMp;
            this.weaponId = weaponId;
        }

        public MonsterBuilderParam(string id, string prefabName)
        {
            this.id = id;
            this.prefabName = prefabName;
        }
    }
}