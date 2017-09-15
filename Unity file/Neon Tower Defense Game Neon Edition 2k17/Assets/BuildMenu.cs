using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {
    public TileManager tileManager;

    void Start() {

    }


    void Update() {
        BuildTowers();
        UpgradeTowers();
    }

    public void BuildTowers()
    {
        if (tileManager.isActive)
        {
            if (tileManager.hasBuilding == false){
                //todo enable menu to build any tower
            }
        }
    }

    public void UpgradeTowers()
    {
        if (tileManager.hasBuilding)
        {
            //todo enable specific tower upgrade menu
        }
    }
}