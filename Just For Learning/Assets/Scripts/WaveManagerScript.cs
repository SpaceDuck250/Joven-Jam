using UnityEngine;
using System.Collections.Generic;
using System;

public class WaveManagerScript : MonoBehaviour
{
    [SerializeField]
    private int enemyKilledThisWave;
    private int enemyKillQuota;

    public List<WaveData> waveList = new List<WaveData>();

    public WaveData currentWave;
    private int currentWaveIndex = 0;

    public SimpleSpawnerScript spawnerScript;

    public delegate void WaveDataHandler(WaveData waveData);
    public event WaveDataHandler OnNewWaveStart;

    private void Start()
    {
        EnemyDeathAlert.OnEnemyDeath += CountEnemy;

        SetWaveBasedOnIndex();
        SetupNewWave(currentWave);
    }

    private void OnDestroy()
    {
        EnemyDeathAlert.OnEnemyDeath -= CountEnemy;
    }

    private void CountEnemy()
    {
        enemyKilledThisWave++;
        if (enemyKilledThisWave == enemyKillQuota)
        {
            if (currentWaveIndex >= waveList.Count)
            {
                return;
            }

            IncrementWaveIndex();
            SetWaveBasedOnIndex();

            SetupNewWave(currentWave);
        }
    }

    private void IncrementWaveIndex()
    {
        if (currentWaveIndex >= waveList.Count)
        {
            return;
        }

        currentWaveIndex++;

    }

    private void SetWaveBasedOnIndex()
    {
        currentWave = waveList[currentWaveIndex];
    }

    private void SetupNewWave(WaveData wave)
    {
        currentWave = wave;

        spawnerScript.spawnTime = wave.spawnInterval;
        spawnerScript.spawnChancePerPoint = wave.spawnChancePerPoint;

        foreach (GameObject newEnemy in wave.newEnemiesToAddList)
        {
            spawnerScript.enemyList.Add(newEnemy);
        }

        enemyKilledThisWave = 0;
        enemyKillQuota = wave.enemyKillRequirementThisWave;

        OnNewWaveStart?.Invoke(wave);
    }

}
