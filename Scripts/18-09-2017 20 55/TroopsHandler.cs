using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsHandler : MonoBehaviour {

    public enum team {teamOne, teamTwo}
    public team state;

    public int moneyDrop;

    public int health;
    public int damage;

    public int index;

    public int attackSpeed;

    public GameObject thisObject;

    public int walkingSpeed;

    public int walkingSpeedRegular;
    public int walkingSpeedDecreased;

    public bool canAttackCastle;
    public bool isTroop = true;

    public float poisonTimerBase;
    public float incendiaryTimerBase;
    public float slowTimerBase;

    private float poisonTimer;
    private float incendiaryTimer;
    private float slowTimer;

    private float gameTick = 1;

    public List<bool> debuff = new List<bool>();
    public List<GameObject> target = new List<GameObject>();

    public void Start() {
        thisObject = gameObject;
    }

    void Update() {
        if(health == 0 || health < 0) {
            Destroy(gameObject);
        }

        gameTick -= 1 * Time.deltaTime;

        if (gameTick < 0) {
            gameTick = 0;
            if (debuff[1] == true) {
                health = -1;
                gameTick = 1;
            }

            if (debuff[2] == true) {
                health = -5;
                gameTick = 1;
            }
        }

        if (slowTimer < 0) {
            debuff[0] = false;
        }
        if (poisonTimer < 0) {
            debuff[1] = false;
        }
        if (incendiaryTimer < 0) {
            debuff[2] = false;
        }

        if (debuff[1] == true) {
            poisonTimer -= 1 * Time.deltaTime;
        } else if (debuff[1] == false) {
            poisonTimer = poisonTimerBase;
        }

        transform.position = Vector3.MoveTowards(transform.position, target[index].transform.position, walkingSpeed);

        if (debuff[0] == true) {
            walkingSpeed = walkingSpeedDecreased;
            slowTimer = -1 * Time.deltaTime;
        } else if (debuff[0] == false) {
            walkingSpeed = walkingSpeedRegular;
            slowTimer = slowTimerBase;
        }

        if (transform.position != target[target.Count].transform.position) {
            if (transform.position == target[index].transform.position) {
                index++;
            }
        }

        if (transform.position == target[target.Count].transform.position) {
            canAttackCastle = true;
        }
    }

    public void OnTriggerEnter(Collider other) {
        other.GetComponent<TowerHandler>().targets.Add(thisObject);
    }

    public void OnTriggerStay(Collider other) {
        if(health == 0 || health < 0) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject);
        }
    }

    public void OnTriggerExit(Collider other) {
        other.GetComponent<TowerHandler>().targets.Remove(thisObject);
    }
}
