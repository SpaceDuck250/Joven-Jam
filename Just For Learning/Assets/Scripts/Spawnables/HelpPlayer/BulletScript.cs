using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public float damageAmount;
    public float moveSpeed;

    public Transform target;

    public void SetupSelf(BulletStartStats bulletStats, Transform target)
    {
        spriteRenderer.sprite = bulletStats.bulletSprite;
        this.damageAmount = bulletStats.damageAmount;
        this.moveSpeed = bulletStats.flySpeed;
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
        if (CheckIfCloseEnough())
        {
            target.gameObject.GetComponent<SimpleHealthScript>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    public bool CheckIfCloseEnough()
    {
        if (target == null)
        {
            return false;
        }

        float closeEnough = 0.1f;
        if (Vector2.Distance(transform.position, target.position) < closeEnough)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject == target.gameObject)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
