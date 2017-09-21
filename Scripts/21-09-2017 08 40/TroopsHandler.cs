using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsHandler : MonoBehaviour {

    public enum team {teamOne, teamTwo}
    public team state;

    public int moneyDrop;

    public string name;

    public int health;
    public int damage;

    public int index;

    public int attackSpeed;

    public GameObject thisObject;

    public float walkingSpeed;

    public float walkingSpeedRegular;
    public float walkingSpeedDecreased;

    public bool canAttackCastle;
    public bool isTroop = true;

    public float poisonTimerBase;
    public float incendiaryTimerBase;
    public float slowTimerBase;

    private float poisonTimer;
    private float incendiaryTimer;
    private float slowTimer;

    private float gameTick = 1;

    public TowerHandler towerRef;

    public List<bool> debuff = new List<bool>();
    public List<GameObject> target = new List<GameObject>();

    public Vector3 targetMod;
    public float height;

    public void Start() {
        thisObject = gameObject;
    }

    void Update() {
        targetMod = new Vector3(target[index].transform.position.x, height, target[index].transform.position.z);

        gameTick -= 1 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetMod, walkingSpeed);

        if (health == 0 || health < 0) {
            Destroy(gameObject);
        }

        if (gameTick < 0) {
            gameTick = 0;
            if (debuff[1] == true) {
                health = health -1;
                print("Applied poison damage, current health of: " + name + " is: " + health);
                print("Poison time remaining: "+poisonTimer);
                gameTick = 1;
            }

            if (debuff[2] == true) {
                health = health -5;
                print("Applied incendiary damage, current health of: " +name +" is: " + health);
                print("Incendiary time remaining: " + incendiaryTimer);
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

        if (debuff[0] == true) {
            walkingSpeed = walkingSpeedDecreased;
            slowTimer = -1 * Time.deltaTime;
        } else if (debuff[0] == false) {
            walkingSpeed = walkingSpeedRegular;
            slowTimer = slowTimerBase;
        }

       if (transform.position == targetMod && transform.position != new Vector3(target[target.Count - 1].transform.position.x, height, target[target.Count - 1].transform.position.z)) {
                if (transform.position == targetMod) {
                index++;
           }
       } 

        if (transform.position == new Vector3(target[target.Count - 1].transform.position.x, height, target[target.Count - 1].transform.position.z)) {
            canAttackCastle = true;
        } 
    }

    public void OnTriggerEnter(Collider other) {
        towerRef = other.GetComponent<TowerHandler>();

        //This checkes if there are any allies within range.
        if (towerRef.state == TowerHandler.team.teamOne && state == team.teamOne) {
            if (!towerRef.allies.Contains(gameObject)) {
                towerRef.allies.Add(gameObject);
            }
        }

        if (towerRef.state == TowerHandler.team.teamTwo && state == team.teamTwo) {
            if (!towerRef.allies.Contains(gameObject)) {
                towerRef.allies.Add(gameObject);
            }
        }

        //This checkes if there are any enemies within range.
        if (towerRef.state == TowerHandler.team.teamOne && state == team.teamTwo) {
            if (!towerRef.targets.Contains(gameObject)) {
                towerRef.targets.Add(gameObject);
            }
        }

        if (towerRef.state == TowerHandler.team.teamTwo && state == team.teamOne) {
            if (!towerRef.targets.Contains(gameObject)) {
                towerRef.targets.Add(gameObject);
            }
        }
    }

    public void OnTriggerStay(Collider other) {

        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamOne && state == team.teamOne) {
            if (health == 0 || health < 0) {
                other.GetComponent<TowerHandler>().allies.Remove(thisObject);
            }
        }

        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamTwo && state == team.teamTwo) {
            if (health == 0 || health < 0) {
                other.GetComponent<TowerHandler>().allies.Remove(thisObject);
            }
        }

                if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamOne && state == team.teamTwo) {
                    if (health == 0 || health < 0) {
                        other.GetComponent<TowerHandler>().targets.Remove(thisObject);
                    }
                }

                if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamTwo && state == team.teamOne) {
                    if (health == 0 || health < 0) {
                        other.GetComponent<TowerHandler>().targets.Remove(thisObject);
                    }
                }
            }


    public void OnTriggerExit(Collider other) {

        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamOne && state == team.teamOne) {
            other.GetComponent<TowerHandler>().allies.Remove(thisObject);
        }

        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamTwo && state == team.teamTwo) {
            other.GetComponent<TowerHandler>().allies.Remove(thisObject);
        }



        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamOne && state == team.teamTwo) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject);
        }

        if (other.GetComponent<TowerHandler>().state == TowerHandler.team.teamTwo && state == team.teamOne) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject);
        }
    }
}
