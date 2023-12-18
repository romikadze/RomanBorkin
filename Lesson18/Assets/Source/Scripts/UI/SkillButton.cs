using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Skill _skill;
    private Button _button;
    [SerializeField] private Image _skillImage;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetSkill(Skill skill)
    {
        _skill = skill;
        _skillImage.sprite = skill.SkillImage;
        _button.onClick.AddListener(() => _skill.Activate());
        skill.OnSkillReady.AddListener(Availability);
    }

    private void Availability(bool value)
    {
        _button.interactable = value;
    }
    
    private void ActivateSkill()
    {
        _skill.Activate();
    }
}
