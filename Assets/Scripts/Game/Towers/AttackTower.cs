using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class AttackTower : Tower
{
    public float damage;

    protected abstract void Shoot();
}
