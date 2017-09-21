using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {
    public TileManager       tileManager;
    public MouseManager      mouseManager;
    public UIScript          uiManager;


    public List<Material>    towerMaterials = new List<Material>();
    public Material          tileMaterial;


    public void TowerManagement()
    {
        tileManager = mouseManager.tileManager;

        if (tileManager!= null && tileManager.isActive)
        {
            if (!tileManager.hasBuilding)
            {
                for (int towerMaterials = 0; towerMaterials < uiManager.towerButtons.Count; towerMaterials++)
                {
                    uiManager.towerButtons[towerMaterials].gameObject.SetActive(true);
                    uiManager.sell.gameObject.SetActive(false);
                }
            }
            else
            {
                uiManager.sell.gameObject.SetActive(true);
                uiManager.SetTowers(0);

            }
        }
    }

    public void BuildTower(int towerInt)
    {
        tileManager.GetComponent<Renderer>().material = towerMaterials[towerInt];
        tileManager.hasBuilding = true;

    }

    public void SellTower()
    {
        print("sold tower");
        tileManager.hasBuilding = false;
        tileManager.GetComponent<Renderer>().material = tileMaterial;
        TowerManagement();

    }
}