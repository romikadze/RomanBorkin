using Source.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsUI : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private TextMeshProUGUI _hpText;
    private ClickBody _clickBody;
    
    private void UpdateHp(float currentHp, float maxHp)
    {
        _hpBar.fillAmount = currentHp / maxHp;
        _hpText.text = (Mathf.Floor(currentHp * 100) / 100).ToString();
    }

    public void SetClickBody(ClickBody clickBody)
    {
        _clickBody = clickBody;
        _clickBody.OnHpChanged += UpdateHp;
    }
}
