using UnityEngine;

public class SlowlyHealScript : MonoBehaviour
{
    public SimpleHealthScript healthScript;

    [SerializeField]
    private float timer;
    public float waitTime;

    public float healAmount = 5;

    private void Update()
    {
        if (healthScript.health == healthScript.maxHealth || healthScript.dead)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            healthScript.Heal(healAmount);
            timer = 0;
        }
    }
}
