using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : MonoBehaviour
{
    public UnityEvent<bool> OnSkillReady;
    public UnityEvent<int> OnSkillActivate;
    private protected abstract bool IsReady { get; set; }
    public abstract string SkillName { get; private protected set; }
    public abstract int ManaCost { get; private protected set; }
    public abstract float Cooldown { get; private protected set; }
    public abstract Sprite SkillImage { get; private protected set; }
    public abstract void Activate();
    public abstract void Setup(string skillName, int manaCost, float cooldown, Sprite skillImage);
}
