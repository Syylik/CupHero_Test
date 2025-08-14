using UnityEngine;

public class HealthUpCard : UpgradeCard
{
    [SerializeField] private PlayerHealth _health;

    public override void Use()
    {
        _health.IncreaseMaxHealth(5);
    }
}
