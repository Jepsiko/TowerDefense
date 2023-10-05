using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpawnShop : MonoBehaviour
{
    public GameObject shopPrefab;

    public bool isAvailable = true;

    public void OnMouseDown()
    {
        Transform shopTransform = GameObject.FindGameObjectWithTag("Shop").transform;
        if (shopTransform.childCount > 0)
        {
            shopTransform.GetChild(0).GetComponent<Shop>().MakeTileAvailable();
            Destroy(shopTransform.GetChild(0).gameObject);
        }
        else if (isAvailable)
        {
            GameObject shop = Instantiate(shopPrefab, shopTransform);
            shop.transform.position = new Vector3(transform.position.x, transform.position.y, shopTransform.position.z);
            shop.GetComponent<Shop>().tile = gameObject;
            isAvailable = false;
        }
    }
}
