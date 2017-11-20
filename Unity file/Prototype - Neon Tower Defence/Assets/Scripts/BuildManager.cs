using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildManager : MonoBehaviour {


    public TileManager tileManager;
    public MouseManager mouseManager;
    public UIManager uiManager;
    public CurrencyManager currencyManager;
    public TowerPrice towerPrice;


    public List<Button> towerButtonList = new List<Button>();
    public List<Material> towerMaterials = new List<Material>();
    public Material tileMaterial;


    public void TowerManagement()
    {
        tileManager = mouseManager.tileManager;
        if (tileManager != null && tileManager.isActive)
        {
            if (!tileManager.hasBuilding)
            {
                for (int towerMaterials = 0; towerMaterials < uiManager.towerButtons.Count; towerMaterials++)
                {
                    uiManager.SetTowers(1);
                    uiManager.sellButon.gameObject.SetActive(false);
                }
            }
            else
            {
                uiManager.SetTowers(0);
                print("4");
                uiManager.sellButon.gameObject.SetActive(true);
            }
        }
        else
        {
            uiManager.SetTowers(0);
        }
    }


    public void BuildTower(int towerInt)
    {
        towerPrice = towerButtonList[towerInt].GetComponent<TowerPrice>();

        if(towerPrice.towerPrice < currencyManager.currency)
        {
            currencyManager.currency -= towerPrice.towerPrice;
            tileManager.hasBuilding = true;
            tileManager.GetComponent<Renderer>().material = towerMaterials[towerInt];
            tileManager.GetComponent<TowerManager>().enabled = true;
            tileManager.GetComponent<TowerManager>().FirstSpawned(towerInt);

            //temporarily
            print(currencyManager.currency);
        }
    }

    public void SellTower()
    {
        //temportarily
        print("sold tower");
        // end of temp.

        tileManager.hasBuilding = false;
        tileManager.GetComponent<Renderer>().material = tileMaterial;
        tileManager.GetComponent<TowerManager>().enabled = false;
        currencyManager.currency += mouseManager.towerHolder.gameObject.GetComponent<TowerManager>().sellPrice;
    }
}
