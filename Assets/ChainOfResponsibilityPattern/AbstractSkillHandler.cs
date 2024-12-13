public abstract class AbstractSkillHandler
{
    protected AbstractSkillHandler _nextSkill;

    public AbstractSkillHandler(AbstractSkillHandler nextSkill)
    {
        _nextSkill = nextSkill;
    }

    public abstract bool CanHandle(int energy);

    public virtual void Handle(int energy)
    {
        _nextSkill?.Handle(energy); //如果下一个技能存在，则调用下一个Handle方法
    }
}