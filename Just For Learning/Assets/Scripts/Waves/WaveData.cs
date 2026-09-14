using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    public string waveName;

    public List<GameObject> newEnemiesToAddList = new List<GameObject>();

    public float spawnInterval;

    public float spawnChancePerPoint;

    public int enemyKillRequirementThisWave;    
}
