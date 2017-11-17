using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSettings", menuName = "WaveSettings/Wave", order = 1)]
public class WavesSettings : ScriptableObject {

    public List<GameObject> wave = new List<GameObject>();
	
}
