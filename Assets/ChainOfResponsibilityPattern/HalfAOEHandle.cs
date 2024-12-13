using UnityEngine;

public class HalfAOEHandle : AbstractSkillHandler
{
    public HalfAOEHandle(AbstractSkillHandler nextSkill) : base(nextSkill) { }

    public override bool CanHandle(int energy)
    {
        return energy is >= 80 and < 100;
    }

    public override void Handle(int energy)
    {
        if (CanHandle(energy))
        {
            Debug.Log("Half AOE handle");
        }
        else
        {
            base.Handle(energy);
        }
    }
}