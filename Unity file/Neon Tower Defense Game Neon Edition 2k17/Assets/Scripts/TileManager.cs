using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public bool isActive;
    public bool hasBuilding;
    void Start() {

    }

    void Update() {
        IfPressed();
    }

    public void IfPressed() // temp code. change to : if X tower has been build on tile replace with the correct material that comes with tower
    {
        if (isActive)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
