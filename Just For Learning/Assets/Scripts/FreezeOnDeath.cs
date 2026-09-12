using UnityEngine;

public class FreezeOnDeath : MonoBehaviour
{
    public SimpleHealthScript healthScript;
    public Rigidbody2D rb;
    public Collider2D selfCollider;

    private void Start()
    {
        healthScript.OnDead += FreezeSelf;
    }

    private void OnDestroy()
    {
        healthScript.OnDead -= FreezeSelf;

    }

    private void FreezeSelf()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        selfCollider.isTrigger = true;
    }
}
