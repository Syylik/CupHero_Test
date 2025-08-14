using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLoop : MonoBehaviour
{
    [SerializeField] private WaveGenerator _waveGenerator;

    public Action OnEndBattle;

    [SerializeField] private Unit _playerUnit;

    /// <summary>
    /// Battle Entry Point
    /// </summary>
    /// <returns></returns>
    public IEnumerator BattleRoutine()
    {
        List<Unit> enemyUnits = new List<Unit>();
        if (_waveGenerator.HasNextWave && !_playerUnit.health.isDead)
        {
            yield return _waveGenerator.SpawnEnemies(enemyUnits);

            while (enemyUnits.Count > 0)
            {
                yield return _playerUnit.MakeMove(FindWeakestUnit(enemyUnits));
                enemyUnits.RemoveAll(e => e.health.isDead);

                foreach (var enemy in enemyUnits) yield return enemy.MakeMove(_playerUnit);
            }

            if (_waveGenerator.IsLastWave) OnEndBattle?.Invoke();
        }
    }

    private Unit FindWeakestUnit(List<Unit> units)
    {
        Unit weakestUnit = null;
        foreach (var unit in units)
        {
            if (unit.health.isDead) continue;
            if (weakestUnit == null || unit.health.HealthValue < weakestUnit.health.HealthValue) weakestUnit = unit;
        }

        return weakestUnit;
    }
}
