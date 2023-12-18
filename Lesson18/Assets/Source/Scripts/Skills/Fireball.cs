using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Fireball : Skill
{
    private protected override bool IsReady { get; set; }
    public override string SkillName { get; private protected set; }
    public override int ManaCost { get; private protected set; }
    public override float Cooldown { get; private protected set; }
    public override Sprite SkillImage { get; private protected set; }

    public override void Setup(string skillName, int manaCost, float cooldown, Sprite skillImage)
    {
        SkillName = skillName;
        ManaCost = manaCost;
        Cooldown = cooldown;
        SkillImage = skillImage;
        IsReady = true;
    }

    public override void Activate()
    {
        Debug.Log( SkillName + "activated!");
        IsReady = false;
        OnSkillReady?.Invoke(IsReady);
        OnSkillActivate?.Invoke(ManaCost);
        StartCoroutine(SkillCooldown());
    }

    private IEnumerator SkillCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        IsReady = true;
        OnSkillReady?.Invoke(IsReady);
    }
}
