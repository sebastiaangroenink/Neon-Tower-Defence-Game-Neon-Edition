using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildMenu : MonoBehaviour {
    public TileManager       tileManager;
    public MouseManager      mouseManager;
    public UIScript          uiManager;
    public CurrencyManager   currencyManager;
    public TowerCosts        towerCosts;


    public List<Material>    towerMaterials = new List<Material>();
    public List<Button>      towerButtonList = new List<Button>();
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
        towerCosts = towerButtonList[towerInt].GetComponent<TowerCosts>();

        if (towerCosts.cost < currencyManager.currency){
            tileManager.GetComponent<Renderer>().material = towerMaterials[towerInt];
            tileManager.hasBuilding = true;
            tileManager.GetComponent<TowerHandler>().enabled = true;
            currencyManager.currency -= towerCosts.cost;
            print(currencyManager.currency);
        }
    }

    public void SellTower()
    {
        print("sold tower");
        tileManager.hasBuilding = false;
        tileManager.GetComponent<Renderer>().material = tileMaterial;
        tileManager.GetComponent<TowerHandler>().enabled = false;
        TowerManagement();
        currencyManager.currency += mouseManager.tileHolder.gameObject.GetComponent<TowerHandler>().sellPrice;
    }
}