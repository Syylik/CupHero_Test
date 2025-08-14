using UnityEngine;

public class DamageUpCard : UpgradeCard
{
    [SerializeField] private ArcherUnit _playerUnit;

    public override void Use()
    {
        _playerUnit.IncreaseDamage(2);
    }
}
