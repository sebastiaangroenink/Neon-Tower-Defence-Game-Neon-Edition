using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour {

    public void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Tile")
        {
            Destroy(col.gameObject);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        print("1");
        if (col.gameObject.tag == "Tile")
        {
            print("2");
            Destroy(col.gameObject);
        }
    }
}
