namespace PrototypePattern.MonsterSpawner
{
    // 使用原型设计模式，允许从一个原型对象生成新的对象实例
    public class Spawner
    {
        private _Monster prototype; // 保存要克隆的原型怪物

        // 构造函数接收一个原型怪物作为参数并保存它。
        public Spawner(_Monster prototype)
        {
            this.prototype = prototype;
        }

        // SpawnMonster 方法返回原型怪物的一个克隆。
        public _Monster SpawnMonster()
        {
            return prototype.Clone();
        }
    }
}