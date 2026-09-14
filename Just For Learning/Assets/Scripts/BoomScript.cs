using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public SimpleHealthScript healthScript;

    public GameObject enemyBoomPrefab;

    private void Start()
    {
        healthScript.OnDead += SpawnBoom;
    }

    private void OnDestroy()
    {
        healthScript.OnDead += SpawnBoom;
    }

    public void SpawnBoom()
    {
        Instantiate(enemyBoomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }




}
