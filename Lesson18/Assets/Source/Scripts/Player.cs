using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [field: SerializeField] public int MaxHP { get; private set; }
    [field: SerializeField] public int MaxMana { get; private set; }

    public UnityEvent<float> OnManaChange;
    public UnityEvent<float> OnHPChange;

    private Skill _skill;
    private int _currentMana;
    private int _currentHP;

    private void Start()
    {
        _currentHP = MaxHP;
        _currentMana = MaxMana;
    }

    public void UpdateMana(int value)
    {
        if (value <= 0) return;

        _currentMana -= value;
        OnManaChange?.Invoke((float)_currentMana/MaxMana);
    }
    public void UpdateHP(int value)
    {
        if (value <= 0) return;
        
        _currentHP -= value;
        OnHPChange?.Invoke((float)_currentHP/MaxHP);
    }

    public void SetSkill(Skill skill)
    {
        _skill = skill;
        _skill.OnSkillActivate.AddListener(UpdateMana);
    }
}
