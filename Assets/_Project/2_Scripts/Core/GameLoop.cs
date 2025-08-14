using System.Collections;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnim;
    [SerializeField] private BattleLoop _battleLoop;
    [SerializeField] private GameOverManager _gameOverManager;
    [SerializeField] private BackgroundScroller _bgScroller;

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

        // Reward

        StartCoroutine(WalkToWave());
    }

    private void OnDisable()
    {
        _battleLoop.OnEndBattle -= () => StopAllCoroutines();
        _battleLoop.OnEndBattle -= _gameOverManager.Victory;
    }
}