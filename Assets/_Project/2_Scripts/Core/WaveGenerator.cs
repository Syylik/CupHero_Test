using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _spawnParent;

    [SerializeField] private LevelInfo _levelInfo;

    private int _currentWaveNum = 0;

    public IEnumerator SpawnEnemies(List<Unit> units)
    {
        if (_currentWaveNum > _levelInfo.waveCount) yield break;

        Wave currentWave = _levelInfo.GetWaveByNumber(_currentWaveNum);

        for (int i = 0; i < currentWave.unitCount; i++)
        {
            units.Add(Instantiate(currentWave.waveMainUnit, transform.position, Quaternion.identity, _spawnParent));
        }

        List<Transform> points = _spawnPoints.ToList();
        foreach (var unit in units)
        {
            int randPoint = Random.Range(0, units.Count);
            yield return unit.MoveToPoint(points[randPoint].position);
            points.RemoveAt(randPoint);
        }

        _currentWaveNum++;
    }

    public bool HasNextWave => _currentWaveNum < _levelInfo.waveCount;
    public bool IsLastWave => _currentWaveNum == _levelInfo.waveCount;
}
