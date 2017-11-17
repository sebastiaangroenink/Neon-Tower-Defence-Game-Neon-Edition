using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour {

    private bool canDestroy = true;

    public void Start() {
        canDestroy = true;
    }

    public void LateUpdate() {
        Destroy(transform.gameObject);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tile" && canDestroy)
        {
            Destroy(col.gameObject);
        }
    }
}
