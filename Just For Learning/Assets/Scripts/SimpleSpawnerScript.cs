using UnityEngine;
using System.Collections.Generic;

public class SimpleSpawnerScript : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public List<Transform> spawnPointList = new List<Transform>();

    public float timer;
    public float spawnTime;

    public float spawnChancePerPoint;

    public float offsetRange;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    public void SpawnEnemy()
    {
        foreach (Transform spawnPoint in spawnPointList)
        {
            if (Random.value <= spawnChancePerPoint)
            {
                float offsetAmount = Random.Range(0, offsetRange);
                int ranVal = Random.Range(0, enemyList.Count);
                GameObject randomEnemy = enemyList[ranVal];
                Instantiate(randomEnemy, spawnPoint.position + (Vector3.left * offsetAmount), Quaternion.identity);
            }
        }
    }
}
