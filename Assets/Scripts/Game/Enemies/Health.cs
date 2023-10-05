using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public UnityEvent<float, float> onDamageTaken;
    public UnityEvent onDeath;

    public void ReceiveDamage(float damage)
    {
        if (health <= 0) return;

        health -= damage;
        onDamageTaken.Invoke(health, maxHealth);
        if (health <= 0) onDeath.Invoke();
    }
}
