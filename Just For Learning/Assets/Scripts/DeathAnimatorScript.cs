using UnityEngine;

public class DeathAnimatorScript : MonoBehaviour
{
    public SimpleEnemyMove simpleEnemyMove;
    public SimpleHealthScript healthScript;

    public Animator animator;

    private void Start()
    {
        healthScript.OnDead += OnDied;
    }

    private void OnDestroy()
    {
        healthScript.OnDead -= OnDied;

    }

    private void OnDied()
    {
        simpleEnemyMove.canMove = false;
        gameObject.layer = LayerMask.NameToLayer("Default");

        animator.SetTrigger("Death");
    }
}
