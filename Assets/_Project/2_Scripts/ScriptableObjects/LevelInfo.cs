using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObjects/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int levelNum;

    [Header("Waves")]
    [SerializeField] private List<Wave> _waves;

    public int waveCount => _waves.Count;

    public Wave GetWaveByNumber(int waveNum) => _waves[waveNum];
}

[System.Serializable]
public struct Wave
{
    public Unit waveMainUnit;
    public int unitCount;
}