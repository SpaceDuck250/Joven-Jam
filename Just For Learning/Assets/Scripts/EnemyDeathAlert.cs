using UnityEngine;

public class EnemyDeathAlert : MonoBehaviour
{
    public delegate void EnemyDeathHandler();

    public static event EnemyDeathHandler OnEnemyDeath;

    public SimpleHealthScript healthScript;

    private void Start()
    {
        healthScript.OnDead += () => { OnEnemyDeath?.Invoke(); };
    }

    private void OnDestroy()
    {
        healthScript.OnDead -= () => { OnEnemyDeath?.Invoke(); };
    }
}
