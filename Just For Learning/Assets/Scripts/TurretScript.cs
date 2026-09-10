using UnityEngine;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public BulletStartStats bulletStats;

    // For later
    public List<BulletStartStats> upgradeBulletStats = new List<BulletStartStats>();

    public float fireTimer;
    public float fireRate;

    public Transform currentTarget = null;

    private List<Collider2D> hitTargetList = new List<Collider2D>(10);
    ContactFilter2D filter = new ContactFilter2D();
   

    public float checkRange;

    public LayerMask hitLayer;

    public Transform firePoint;

    private void Start()
    {
        filter.SetLayerMask(hitLayer);
        
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            
            if (SearchForNewClosestTarget(out currentTarget))
            {
                //print(currentTarget);
                FireNewBullet();
            }
        }
    }

    public void FireNewBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        BulletScript bulletScript = newBullet.GetComponent<BulletScript>();
        bulletScript.SetupSelf(bulletStats, currentTarget);
    }

    public bool SearchForNewClosestTarget(out Transform thisClosestEnemy)
    {
        hitTargetList.Clear();

        Physics2D.OverlapCircle(transform.position, checkRange, filter, hitTargetList);

        float closestDistance = Mathf.Infinity;
        thisClosestEnemy = null;

        foreach (Collider2D collider in hitTargetList)
        {
            float distanceToThatEnemy = Vector2.Distance(transform.position, collider.gameObject.transform.position);
            if (distanceToThatEnemy < closestDistance)
            {
                closestDistance = distanceToThatEnemy;
                thisClosestEnemy = collider.gameObject.transform;
            }
        }

        bool foundEnemy = thisClosestEnemy != null;

        return foundEnemy;
    }

}
