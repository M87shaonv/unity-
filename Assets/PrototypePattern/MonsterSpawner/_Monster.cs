namespace PrototypePattern.MonsterSpawner
{
    public abstract class _Monster
    {
        // Clone 方法实现了原型设计模式，派生类应该重写此方法以返回自身的克隆。
        public abstract _Monster Clone();

        // Talk 方法是一个抽象方法，派生类应根据自己的特性实现不同的对话内容。
        public abstract void Talk();
    }
}