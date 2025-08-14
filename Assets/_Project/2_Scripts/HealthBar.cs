using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HealthBar
{
    [SerializeField] private Image _healthBar;

    public void Init(Health health) => health.OnHealthChanged.AddListener(UpdateBar);

    public void UpdateBar(float health, float maxHealth) => _healthBar.fillAmount = health / maxHealth;
}
