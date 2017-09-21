using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public bool isActive;
    public bool hasBuilding;

    void Update() {
        IfPressed();
    }

    public void IfPressed()
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
