using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    public RaycastHit hit;

    public TileManager tileManager;

    public GameObject towerHolder;


	void Update () {
        ShootRay();
        KeyBindings();
	}

    void ShootRay() // schiet een ray naar het scherm wat tegen tiles aankomt en de Isactive variable
        // op true zet waardoor die rood wordt. ook vult hij zijn eigen tileManager met de TileManager van de tile.
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100) && hit.transform.tag == "Tile")
            {
                    tileManager = hit.transform.GetComponent<TileManager>();
                    tileManager.isActive = true;
            }
        }
    }

    void KeyBindings() // als je op escape drukt de-select je de tile en wordt hij weer wit.
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (tileManager.isActive)
            {
                tileManager.isActive = false;
                tileManager = null;
            }
        }
    }
}
