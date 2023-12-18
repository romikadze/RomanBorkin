using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private SkillButton[] _skillButtons;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _manaBar;
    private Player _player;

    private void Awake()
    {

    }

    private void UpdateManaBar(float value)
    {
        _manaBar.fillAmount = value;
    }

    private void UpdateHPBar(float value)
    {
        _hpBar.fillAmount = value;
    }

    public void SetPlayer(Player player)
    {
        _player = player;
        _player.OnManaChange.AddListener(UpdateManaBar);
        _player.OnHPChange.AddListener(UpdateHPBar);
        _hpBar.fillAmount = 1;
        _manaBar.fillAmount = 1;
    }

    public void SetAttack(Attack attack)
    {
        _attackButton.onClick.RemoveAllListeners();
        _attackButton.onClick.AddListener(attack.Activate);
    }

    public void SetSkill(Skill skill, int index)
    {
        _skillButtons[index].SetSkill(skill);
    }
}
