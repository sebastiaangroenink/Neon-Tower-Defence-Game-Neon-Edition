using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour {

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tile")
        {
            Destroy(col.gameObject);
        }
    }
}
