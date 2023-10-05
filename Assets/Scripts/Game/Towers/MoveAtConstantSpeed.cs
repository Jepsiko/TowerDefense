using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtConstantSpeed : MonoBehaviour
{
    public float speed;

    private void Update() {
        Vector3 moveDirection = transform.up;
        moveDirection.Normalize();
        transform.position += speed * Time.deltaTime * moveDirection;
    }
}
