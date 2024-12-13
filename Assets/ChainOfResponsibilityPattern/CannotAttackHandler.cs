using UnityEngine;

public class CannotAttackHandler : AbstractSkillHandler
{
    public CannotAttackHandler(AbstractSkillHandler nextSkill) : base(nextSkill) { }

    public override bool CanHandle(int energy)
    {
        return energy < 20;
    }

    public override void Handle(int energy)
    {
        if (CanHandle(energy))
        {
            Debug.Log("Cannot attack!");
        }
        else
        {
            base.Handle(energy);
        }
    }
}