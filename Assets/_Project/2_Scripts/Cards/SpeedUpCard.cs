using UnityEngine;

public class SpeedUpCard : UpgradeCard
{
    [SerializeField] private ArcherUnit _playerUnit; 
    public override void Use()
    {
        _playerUnit.IncreaseSpeed(0.5f);
    }
}
