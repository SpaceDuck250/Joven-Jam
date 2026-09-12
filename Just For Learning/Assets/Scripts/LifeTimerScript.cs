using UnityEngine;

public class LifeTimerScript : MonoBehaviour
{
    public float timer;
    public float dieTime;

    public Animator animator;
    public string deathAnimName;

    private bool dead => timer >= dieTime;

    private void Update()
    {
        if (dead)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= dieTime)
        {
            DoDieAnimation();
        }
    }

    // Will call Die()
    public void DoDieAnimation()
    {
        animator.SetTrigger(deathAnimName);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
