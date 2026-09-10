using UnityEngine;
using System.Collections;

public class EnemyHitColorer : MonoBehaviour
{
    public SimpleHealthScript healthScript;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        healthScript.OnHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        healthScript.OnHealthChanged -= OnHealthChanged;

    }

    private void OnHealthChanged(float newHealth, float change)
    {
        if (change < 0)
        {
            StopAllCoroutines();
            StartCoroutine(TurnRedForABit());
        }
    }

    public IEnumerator TurnRedForABit()
    {
        spriteRenderer.color = Color.red;

        float waitTime = 0.2f;
        yield return new WaitForSeconds(waitTime);

        spriteRenderer.color = Color.white;
    }
}
