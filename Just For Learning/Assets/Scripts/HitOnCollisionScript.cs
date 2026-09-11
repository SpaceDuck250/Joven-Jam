using UnityEngine;

public class HitOnCollisionScript : MonoBehaviour
{
    public string targetTag;

    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            SimpleHealthScript healthScript = collision.gameObject.GetComponent<SimpleHealthScript>();
            healthScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
