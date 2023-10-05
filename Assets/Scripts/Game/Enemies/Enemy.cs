using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthBar))]
public class Enemy : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Start()
    {
        GetComponent<Health>().onDeath.AddListener(DestroyGameObject);
        GetComponent<Health>().onDamageTaken.AddListener(GetComponent<HealthBar>().UpdateHealth);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
