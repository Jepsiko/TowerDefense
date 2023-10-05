using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DealDamageToBase : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        damage = GetComponent<Enemy>().damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Base")
        {
            other.GetComponent<Health>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
