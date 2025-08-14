using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Unit _player;

    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _attackSpeedText;

    public void UpdateStates()
    {
        _damageText.text = _player.Damage.ToString();
        _attackSpeedText.text = _player.AttackSpeed.ToString();
    }
}