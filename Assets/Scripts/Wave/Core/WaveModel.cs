using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Tanks/Wave Data")]
public class WaveModel : ScriptableObject
{
    [Serializable]
    public class EnemySpawnData
    {
        public EnemyTankModel.TankType tankType;
        public int count;
    }

    public int waveNumber;
    public float timeBetweenSpawns = 2f;
    public List<EnemySpawnData> enemiesToSpawn = new List<EnemySpawnData>();
    public string waveStartMessage;
    public AudioClip waveStartSound;
}