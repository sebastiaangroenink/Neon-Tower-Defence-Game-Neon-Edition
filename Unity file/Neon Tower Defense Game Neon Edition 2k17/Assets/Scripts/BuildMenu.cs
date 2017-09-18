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

        if (tileManager.isActive)
        {
            if (tileManager.hasBuilding == false){
                for(int towers =0; towers< uiManager.towers.Count; towers++)
                {
                    uiManager.towers[towers].GetComponent<CanvasGroup>().alpha = 1;
                }
                uiManager.sell.GetComponent<CanvasGroup>().alpha = 1;
            }
            else if(tileManager.hasBuilding)
            {
                //todo show sell UI button
            }
        }
        else
        {
            for(int towers=0; towers<uiManager.towers.Count; towers++)
            {
                uiManager.towers[towers].GetComponent<CanvasGroup>().alpha = 0;
            }
            uiManager.sell.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    public void BuildTower(int towerInt)
    {
        Instantiate(towers[towerInt],new Vector3(tileManager.gameObject.transform.position.x,tileManager.gameObject.transform.position.y+1,tileManager.gameObject.transform.position.z), Quaternion.Euler(Vector3.right * 90));
    }
}