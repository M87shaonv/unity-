using UnityEngine;

public class AttackOneEnemyHalfDamageHandle : AbstractSkillHandler
{
    public AttackOneEnemyHalfDamageHandle(AbstractSkillHandler nextSkill) : base(nextSkill) { }

    public override bool CanHandle(int energy)
    {
        return energy is >= 20 and < 50;
    }

    public override void Handle(int energy)
    {
        if (CanHandle(energy))
        {
            Debug.Log("AttackOneEnemyHalfDamageHandle");
        }
        else
        {
            base.Handle(energy);
        }
    }
}