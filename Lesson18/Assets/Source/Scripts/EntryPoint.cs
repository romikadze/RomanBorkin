using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private Skill _skill;

    [SerializeField] private Sprite _skillImage;
    [SerializeField] private Fireball _fireball;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Player _player;

    private void Start()
    {
        _skill = Instantiate(_fireball);
        _skill.Setup("Fireball", 10, 2f, _skillImage);
        _playerUI.SetPlayer(_player);
        _playerUI.SetSkill(_skill, 0);
        _player.SetSkill(_skill);
    }
}
