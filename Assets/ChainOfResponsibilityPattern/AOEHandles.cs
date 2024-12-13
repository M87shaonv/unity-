using System;
using UnityEngine;

public class AOEHandle : AbstractSkillHandler
{
    public AOEHandle(AbstractSkillHandler nextSkill) : base(nextSkill) { }

    public override bool CanHandle(int energy)
    {
        return energy == 100;
    }

    public override void Handle(int energy)
    {
        if (CanHandle(energy))
        {
            Debug.Log("AOE Handle");
        }
        else
        {
            base.Handle(energy);
        }
    }
}