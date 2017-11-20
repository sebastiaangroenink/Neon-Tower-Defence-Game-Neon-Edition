using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public MouseManager mouseManager;

    public bool isActive;
    public bool hasBuilding;
    public Material highLightMaterial;


    private void Start() // pakt MouseManager van mousemanager omdat het een prefab is en dit niet in inspector kan.
    {
        mouseManager = GameObject.Find("MouseManager").GetComponent<MouseManager>();
    }
    void Update()
    {
        IfPressed();
    }

    void IfPressed()
    {        
        // als de speler een ander tile heeft geselecteerd zet dit tile isActive weer op false
        if(isActive && mouseManager.tileManager != null && mouseManager.tileManager != transform.GetComponent<TileManager>())
        {
            isActive = false;
        }
    }
}
