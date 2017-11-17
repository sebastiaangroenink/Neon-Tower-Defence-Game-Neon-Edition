using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public MouseManager mouseManager;

    public bool isActive;
    public bool hasBuilding;


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
        if (isActive) // als isActive trueis (wordt vanuit andere scripts gedaan wordt de tile rood,
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {// en anders wit.
            transform.GetComponent<Renderer>().material.color = Color.white; 
        }
         
        // als de speler een ander tile heeft geselecteerd zet dit tile isActive weer op false
        if(isActive && mouseManager.tileManager != null && mouseManager.tileManager != transform.GetComponent<TileManager>())
        {
            isActive = false;
        }
    }
}
