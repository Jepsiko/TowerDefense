using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestroyShop : MonoBehaviour
{
    public GameObject shop;

    private void OnMouseDown()
    {
        shop.GetComponent<Shop>().MakeTileAvailable();
        Destroy(shop);
    }
}
