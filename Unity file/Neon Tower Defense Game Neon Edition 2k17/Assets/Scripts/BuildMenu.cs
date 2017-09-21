using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {
    public TileManager   tileManager;
    public MouseManager  mouseManager;
    public UIScript      uiManager;

    public List<GameObject> towers = new List<GameObject>();

    void Start() {

    }
    public void TowerManagement()
    {
        tileManager = mouseManager.tileManager;

        if (tileManager!= null && tileManager.isActive)
        {
            if (tileManager.hasBuilding == false){
                for(int towers =0; towers< uiManager.towers.Count; towers++)
                {
                    uiManager.towers[towers].gameObject.SetActive(true);
                }

            }
            else if(tileManager.hasBuilding)
            {
                uiManager.sell.gameObject.SetActive(false);
            }
        }
        else if (tileManager != null && !tileManager.isActive) {
            {
                for (int towers = 0; towers < uiManager.towers.Count; towers++)
                {
                    uiManager.towers[towers].gameObject.SetActive(false);
                    uiManager.sell.gameObject.SetActive(false);
                }
            }
        }
    }

    public void BuildTower(int towerInt)
    {
        GameObject spawnTower = towers[towerInt];
        Instantiate(spawnTower,tileManager.transform);
        tileManager.hasBuilding = true;

    }

    public void SellTower()
    {
        print("sold tower");
        tileManager.hasBuilding = false;
    }
}