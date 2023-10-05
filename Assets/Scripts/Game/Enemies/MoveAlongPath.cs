using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class MoveAlongPath : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    private int _current;

    private void Start() {
        speed = GetComponent<Enemy>().speed;
        transform.position = waypoints[0].position;
        _current = 1;
    }

    private void Update() {
        if (_current < waypoints.Length)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[_current].position, speed*Time.deltaTime);

        if (transform.position == waypoints[_current].position)
        {
            _current++;
        }
    }
}
