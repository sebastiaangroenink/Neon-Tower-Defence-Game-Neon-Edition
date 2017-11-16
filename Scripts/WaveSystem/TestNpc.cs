using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNpc : MonoBehaviour {

    public SpawnManager spawn;

    public void Awake() {
        spawn = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    public void Start() {
        spawn.currentStaticWave.Add(gameObject);
    }

    public void OnMouseDown() {
        spawn.currentStaticWave.Remove(gameObject);
        Destroy(gameObject);
    }
}
