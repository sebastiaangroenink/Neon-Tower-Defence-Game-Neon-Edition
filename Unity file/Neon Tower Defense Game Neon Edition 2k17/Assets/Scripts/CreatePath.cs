using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour {

    private bool canDestroy = true;

    public void Start() {
        canDestroy = true;
    }

    public void Update() {
        canDestroy = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tile" && canDestroy)
        {
            Destroy(col.gameObject);
        }
    }
}
