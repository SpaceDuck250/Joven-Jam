using UnityEngine;
using System.Collections.Generic;

public class BoomPrefabScript : MonoBehaviour
{
    public List<Collider2D> collidersList = new List<Collider2D>(20);

    public float boomRadius;

    public ContactFilter2D filter;

    public LayerMask hitLayer;

    public float damage;

    private void Start()
    {
        filter.SetLayerMask(hitLayer);
    }

    public void HitAllTargetsInRange()
    {
        print("Called");

        collidersList.Clear();

        Physics2D.OverlapCircle(transform.position, boomRadius, filter, collidersList);

        foreach (Collider2D collider in collidersList)
        {
            //SimpleHealthScript healthScript = collider.gameObject.GetComponent<SimpleHealthScript>();
            //if (healthScript != null)
            //{
            //    healthScript.TakeDamage(damage);
            //}

            Destroy(collider.transform.parent.gameObject);
            print("Called");
        }

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, boomRadius);
    //}
}
