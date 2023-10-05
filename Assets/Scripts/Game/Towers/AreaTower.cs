using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AreaTower : AttackTower
{
    private void Update() {
        _timePassed += Time.deltaTime;
        if (_timePassed > 1 / rate)
        {
            Shoot();
            _timePassed = 0f;
        }
    }

    protected override void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            if ((transform.position - enemy.transform.position).magnitude < range)
            {
                enemy.GetComponent<Health>().ReceiveDamage(damage);
            }
        }
    }
}
