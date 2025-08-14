using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public int money { get; private set; }

    public Action<int> OnMoneyChanged;

    // i'm very sad about it
    public static Bank Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool TryBuy(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            OnMoneyChanged?.Invoke(money);
            return true;
        }
        return false;
    }

    public void AddMoney()
    {
        money++;
        OnMoneyChanged?.Invoke(money);
    }
}
