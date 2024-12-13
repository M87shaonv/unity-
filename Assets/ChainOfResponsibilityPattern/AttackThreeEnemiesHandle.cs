using UnityEngine;

public class AttackThreeEnemiesHandle : AbstractSkillHandler
{
    public AttackThreeEnemiesHandle(AbstractSkillHandler nextSkill) : base(nextSkill) { }

    public override bool CanHandle(int energy)
    {
        return energy is >= 50 and < 80;
    }

    public override void Handle(int energy)
    {
        if (CanHandle(energy))
        {
            Debug.Log("AttackThreeEnemiesHandle");
        }
        else
        {
            base.Handle(energy);
        }
    }
}