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
    public TowerHandler      otherTowerScriptReference;
    public TowerHandler      thisTowerScriptReference;


    public List<Material>    towerMaterials = new List<Material>();
    public List<GameObject>  towerUpgrades = new List<GameObject>();
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
        otherTowerScriptReference = towerUpgrades[towerInt].GetComponent<TowerHandler>();
        thisTowerScriptReference = tileManager.GetComponent<TowerHandler>();
        towerCosts = towerButtonList[towerInt].GetComponent<TowerCosts>();

        if (towerCosts.cost < currencyManager.currency){
            tileManager.GetComponent<Renderer>().material = towerMaterials[towerInt];
            tileManager.hasBuilding = true;
            tileManager.GetComponent<TowerHandler>().enabled = true;
            currencyManager.currency -= towerCosts.cost;

            thisTowerScriptReference.name = otherTowerScriptReference.name;
            thisTowerScriptReference.description = otherTowerScriptReference.description;
            thisTowerScriptReference.sellPrice = otherTowerScriptReference.sellPrice;
            thisTowerScriptReference.damage = otherTowerScriptReference.damage;
            thisTowerScriptReference.canAttack = otherTowerScriptReference.canAttack;
            thisTowerScriptReference.arialRangeScale = otherTowerScriptReference.arialRangeScale;
            thisTowerScriptReference.projectileIntervalBase = otherTowerScriptReference.projectileIntervalBase;
            thisTowerScriptReference.projectileSpeed = otherTowerScriptReference.projectileSpeed;
            thisTowerScriptReference.debuff = otherTowerScriptReference.debuff;
            thisTowerScriptReference.towerSkin = otherTowerScriptReference.towerSkin;
            thisTowerScriptReference.projectileReference = otherTowerScriptReference.projectileReference;

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