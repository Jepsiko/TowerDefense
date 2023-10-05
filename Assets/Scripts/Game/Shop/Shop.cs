using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject gunTower;
    public GameObject sniperTower;
    public GameObject shockTower;
    public GameObject boomerangTower;
    public GameObject missileTower;
    public GameObject slowTower;

    public float range;

    public GameObject tile;

    private void Start() {
        GameObject[] towers = new GameObject[]
        {
            gunTower, sniperTower, shockTower, boomerangTower, missileTower, slowTower
        };
        for (int i = 0; i < 6; i++)
        {
            GameObject tower = Instantiate(towers[i], PosFromIndex(i), Quaternion.identity, transform);
            tower.transform.localScale = Vector3.one / 5;
            tower.GetComponent<Tower>().enabled = false;
            ClickToBuy buy = tower.AddComponent<ClickToBuy>();
            buy.tile = tile;
            buy.tower = towers[i];
            foreach (var renderer in tower.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sortingLayerName = "Shop";
            }
        }
    }

    public void MakeTileAvailable()
    {
        tile.GetComponent<ClickToSpawnShop>().isAvailable = true;
    }

    private Vector3 PosFromIndex(int i)
    {
        return transform.position + Quaternion.AngleAxis(i*60, Vector3.forward) * (Vector3.right * range);
    }
}
