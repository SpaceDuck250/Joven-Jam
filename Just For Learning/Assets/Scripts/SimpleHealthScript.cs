using UnityEngine;
using System;

public class SimpleHealthScript : MonoBehaviour
{
    public float health => _health;

    private float _health;
    public float maxHealth;
    public event Action<float, float> OnHealthChanged;
    public event Action OnDead;

    public bool dead = false;

    private void Start()
    {
        _health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Die();
        }

        OnHealthChanged?.Invoke(_health, -damage);
    }

    public void Heal(float healAmount)
    {
        if (dead)
        {
            return;
        }

        _health += healAmount;
        if (_health >= maxHealth)
        {
            _health = maxHealth;
        }

        OnHealthChanged?.Invoke(_health, healAmount);
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
