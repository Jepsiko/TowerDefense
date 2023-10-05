using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float range;
    public float rate;

    protected float _timePassed = 0f;

    public void OnMouseDown()
    {
        Upgrade();
    }

    public void Upgrade()
    {
        range *= 1.1f;
        rate *= 1.5f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
