using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuy : MonoBehaviour
{
    public GameObject tile;
    public GameObject tower;

    public void OnMouseDown()
    {
        Instantiate(tower, tile.transform.position, Quaternion.identity, tile.transform);
        Destroy(GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject);
    }
}
