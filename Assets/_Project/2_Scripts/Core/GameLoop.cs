using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnim;
    [SerializeField] private BattleLoop _battleLoop;
    [SerializeField] private CardPurchase _cardPurchase;
    [SerializeField] private GameOverManager _gameOverManager;
    [SerializeField] private BackgroundScroller _bgScroller;

    public Action OnRewarded;

    private void Start() => StartCoroutine(WalkToWave());

    private void OnEnable()
    {
        _battleLoop.OnEndBattle += () => StopAllCoroutines();
        _battleLoop.OnEndBattle += _gameOverManager.Victory;
    }

    private IEnumerator WalkToWave()
    {
        _bgScroller.isScrolling = true;
        _playerAnim.StartRunAnim();

        yield return new WaitForSeconds(Random.Range(1.5f, 4f));

        _playerAnim.EndRunAnim();
        _bgScroller.isScrolling = false;
        yield return _battleLoop.StartCoroutine(_battleLoop.BattleRoutine());

        yield return _cardPurchase.StartCoroutine(_cardPurchase.ChoseReward());

        StartCoroutine(WalkToWave());
    }

    private void OnDisable()
    {
        _battleLoop.OnEndBattle -= () => StopAllCoroutines();
        _battleLoop.OnEndBattle -= _gameOverManager.Victory;
    }
}