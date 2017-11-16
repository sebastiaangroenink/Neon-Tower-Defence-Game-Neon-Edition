using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    #region variables
    [Header("Preset Wave List:")]
    public List<WavesSettings> waves = new List<WavesSettings>();

    [Header("Currently Spawned Npcs:")]
    [Tooltip("Represents the current wave data in the *Wave ScriptableObjects*...")]
    public List<GameObject> currentStaticWave = new List<GameObject>();

    [Header("Game Checks:")]
    public bool waveDone = false; //Defines if a wave is going on or not...
    public bool waveStart = false; //Defines if there is a wave happening right now...
    public bool allSpawned = false; //Defines if all enemys in the current wave have spawned...

    private bool clear = false; //checks if the wave has ended...

    [Header("Wave:")]
    public int waveID = 0; // Wave + 1 is equal to the wave...
    private int localEnemyID = 0; //Enemy index refererence...

    [Header("Enemy Spawn Speed:")]
    public float enemySpawnInterval = 2; //Enemy spawn timer interval...
    #endregion

    //Regular checks...
    public void Update() {
        WaveCheck();
    }

    //Root of the whole wave system...
    public void WaveActivationNode() {
       if (!waveStart) {
            waveDone = false;
            StartWave();

           if (waveID == (waves.Count - 1)) {
               print("Starting the final wave...");
           } else if(waveID != waves.Count) {
               print("Starting wave " + (waveID + 1) + "...");
                }
            }
        }

    //Checks if wave is cleared...
    private void WaveCheck() {
        if(clear && allSpawned && currentStaticWave.Count == 0) {
                    WaveCleared();
                }
            }

    //Defines that a wave has started and commences to spawn entitys...
    public void StartWave() {
        if (waveID != waves.Count) {
            waveStart = true;
            SpawnProcess();
        } else {
            print("All waves are completed");
        }
    }

    //Sets up the wave by referencing a preset list to the one that is about to spawn...
    public void SpawnProcess() {
        EnemyCheck();
    }

    //Checks if the wave is still going on and if all entitys of this wave have spawned...
    public void EnemyCheck() {
        if (localEnemyID != (waves[waveID].wave.Count - 1) && !waveDone || !allSpawned) {
            StartCoroutine(WaveSpawn(enemySpawnInterval, localEnemyID));
        } else {
            print("All enemys from this wave have spawned...");
        }
    }

    //Checks which index of the wave its npc it should spawn, and if they all have spawned already or not...
    public IEnumerator WaveSpawn(float timer, int enemyID) {
        enemyID = localEnemyID;

        yield return new WaitForSeconds(enemySpawnInterval);
        if (enemyID != waves[waveID].wave.Count && !allSpawned) {
            Instantiate(waves[waveID].wave[enemyID], Vector3.zero, Quaternion.identity);
            localEnemyID++;
            EnemyCheck();
        } else {
            clear = true;
        }
    
        if(localEnemyID == waves[waveID].wave.Count) {
            allSpawned = true;
        }
    }

    //Deactivates certain statements upon completion of the wave...
    public void WaveCleared() {
        localEnemyID = 0;
        clear = false;
        waveDone = true;
        waveStart = false;
        allSpawned = false;

        if (waveID == (waves.Count - 1)) {
            print("Ended the final wave...");
        } else {
            print("Ended wave " + (waveID + 1) + "...");
        }

        waveID++;
    }
}
