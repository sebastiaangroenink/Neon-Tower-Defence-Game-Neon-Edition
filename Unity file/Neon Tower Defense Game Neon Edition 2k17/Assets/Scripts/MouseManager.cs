using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public RaycastHit hit;

    public TileManager tileManager;
    public BuildMenu buildMenu;
    public UIScript uiManager;

    public GameObject tileHolder;

    void Update()
    {
        ShootRay();
        KeyBindings();
    }

    void ShootRay()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.tag == "Tile")
            {
                if (tileManager != null && tileManager.isActive)
                {
                    tileManager.isActive = false;
                }
                tileManager = hit.transform.GetComponent<TileManager>();
                tileManager.isActive = true;
                tileHolder = hit.transform.gameObject;
            }
            buildMenu.TowerManagement();
        }
    }

    public void KeyBindings()
    {
        if (Input.GetButtonDown("Escape")) // temp code. fix with comments in TileManager
        {
            if (tileManager.isActive)
            {
                tileManager.isActive = false;
                buildMenu.TowerManagement();
            }
        }
    }
}