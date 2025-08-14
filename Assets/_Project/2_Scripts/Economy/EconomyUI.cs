using TMPro;
using UnityEngine;

public class EconomyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Bank _bank;

    private void OnEnable() => _bank.OnMoneyChanged += UpdateMoneyText;

    private void UpdateMoneyText(int money)
    {
        _moneyText.text = money.ToString();
    }

    private void OnDisable() => _bank.OnMoneyChanged -= UpdateMoneyText;
}
