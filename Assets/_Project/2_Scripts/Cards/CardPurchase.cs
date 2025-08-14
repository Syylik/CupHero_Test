using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CardPurchase : MonoBehaviour
{
    [SerializeField] private GameObject _cardChosePanel;

    [SerializeField] private UnityEvent OnBuy;

    private GameLoop _gameLoop;

    private bool _isBought;

    [Zenject.Inject]
    public void Init(GameLoop gameLoop)
    {
        _gameLoop = gameLoop;
    }

    public IEnumerator ChoseReward()
    {
        _isBought = false;
        _cardChosePanel.SetActive(true);

        yield return new WaitUntil(() => _isBought);

        _cardChosePanel.SetActive(false);
    }

    public void Buy(UpgradeCard card)
    {
        if (Bank.Instance.TryBuy(card.CardCost))
        {
            card.Use();
            OnBuy?.Invoke();
            _isBought = true;
        }
    }
}
