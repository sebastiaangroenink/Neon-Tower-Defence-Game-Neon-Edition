﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public RaycastHit hit;

    public TileManager tileManager;
    public BuildMenu buildMenu;

    public GameObject tileHolder;


    void Start()
    {

    }


    void Update()
    {
        ShootRay();
        KeyBindings();
    }

    void ShootRay()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (tileHolder != null)
            {
                tileManager.isActive = false;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.tag == "Tile")
            {
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
            }
        }
    }
}