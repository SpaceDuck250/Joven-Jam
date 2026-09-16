using UnityEngine;

public class CollisionBoomScript : MonoBehaviour
{
    public BoomScript boomScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Friendly"))
        {
            boomScript.SpawnBoom();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Friendly"))
        {
            boomScript.SpawnBoom();
        }
    }
}
