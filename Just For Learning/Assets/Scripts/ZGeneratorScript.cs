using UnityEngine;
using System;

public class ZGeneratorScript : MonoBehaviour
{
    public GameObject zPrefab;

    public float timer;
    public float waitTime;

    public bool generating = true;

    public event Action OnSpawnZ;

    public Transform spawnPoint;

    private void Update()
    {
        if (!generating)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            SpawnZ();
            timer = 0;
        }
    }

    public void SpawnZ()
    {
        GameObject newZ = Instantiate(zPrefab, spawnPoint.position, Quaternion.identity);

        newZ.GetComponent<ZAnimatorScript>().DoJumpAnim();

        OnSpawnZ?.Invoke();
    }
}
