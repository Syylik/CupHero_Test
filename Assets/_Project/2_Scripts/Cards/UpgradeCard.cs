using UnityEngine;

public abstract class UpgradeCard : MonoBehaviour
{
    [SerializeField] private int _cardCost;
    public int CardCost => _cardCost;
    public abstract void Use();
}
