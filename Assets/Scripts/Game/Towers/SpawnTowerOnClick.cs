using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnTowerOnClick : MonoBehaviour
{
    public GameObject towerPrefab;

    private bool isAvailable = true;

    public void OnMouseDown()
    {
        if (isAvailable) Instantiate(towerPrefab, this.transform.position, Quaternion.identity, this.transform);
        isAvailable = false;
    }
}
