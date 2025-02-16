using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveData", menuName = "Tank/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    public EnemyTankData[] enemyTanks;
    public bool isBossWave;
}