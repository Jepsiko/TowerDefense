using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : AttackTower
{
    public float rotationSpeed;
    public float projectileSpeed;

    public GameObject projectilePrefab;

    public Transform turret;
    public Transform shootPoint;

    public GameObject target;

    private void Update()
    {
        _timePassed += Time.deltaTime;
        FindTarget();
        if (target != null)
        {
            RotateTurret();
            if (FacingTarget() && _timePassed > 1 / rate)
            {
                Shoot();
                _timePassed = 0f;
            }
        }
    }

    private void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            if ((transform.position - enemy.transform.position).magnitude < range)
            {
                target = enemy;
                return;
            }
        }
        target = null;
    }

    private bool FacingTarget()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        return Quaternion.Angle(turret.rotation, targetRotation) < 10;
    }

    private void RotateTurret()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        turret.rotation = Quaternion.RotateTowards(turret.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    protected override void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, turret.rotation, transform);
        projectile.GetComponent<MoveAtConstantSpeed>().speed = projectileSpeed;
        projectile.GetComponent<DestroyWhenOutOfRange>().tower = this;
        projectile.GetComponent<DealDamageToEnemies>().damage = damage;
    }
}
