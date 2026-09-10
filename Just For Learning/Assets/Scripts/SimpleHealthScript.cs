using UnityEngine;
using System;

public class SimpleHealthScript : MonoBehaviour
{
    private float health;
    public float maxHealth;
    public event Action<float, float> OnHealthChanged;
    public event Action OnDead;

    public bool dead = false;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        OnHealthChanged?.Invoke(health, -damage);
    }

    public void Heal(float healAmount)
    {
        if (dead)
        {
            return;
        }

        health += healAmount;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        OnHealthChanged?.Invoke(health, healAmount);
    }

    public void Die()
    {
        dead = true;
        OnDead?.Invoke();

        //Destroy(gameObject);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }


}
