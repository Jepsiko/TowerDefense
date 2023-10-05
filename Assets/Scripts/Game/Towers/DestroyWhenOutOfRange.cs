using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfRange : MonoBehaviour
{
    public Tower tower;

    private void Update() {
        if ((transform.position - tower.transform.position).magnitude > tower.range)
        {
            Destroy(gameObject);
        }
    }
}
