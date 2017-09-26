using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsHandler : MonoBehaviour {

    public enum Team { teamOne, teamTwo }
    public Team state;

    public int moneyDrop;

    public string name;

    public int health;
    public int damage;

    private int index;

    public float attackSpeed;

    private GameObject thisObject;

    private float walkingSpeed;

    public float walkingSpeedRegular = 2;
    public float walkingSpeedDecreased = 1;

    private bool canAttackCastle;

    public static bool isTroop = true;

    private static float poisonTimerBase;
    private static float incendiaryTimerBase;
    private static float slowTimerBase;

    private float poisonTimer;
    private float incendiaryTimer;
    private float slowTimer;

    private static float gameTick = 1;

    private TowerHandler towerRef;

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

        if (health < 1) {
            Destroy(gameObject);
        }

        if (gameTick < 0) {
            gameTick = 0;
            if (debuff[1]) {
                health = health - 1;
                print("Applied poison damage, current health of: " + name + " is: " + health);
                print("Poison time remaining: " + poisonTimer);
            }

            if (debuff[2]) {
                health = health - 5;
                print("Applied incendiary damage, current health of: " + name + " is: " + health);
                print("Incendiary time remaining: " + incendiaryTimer);
            }
            gameTick = 1;
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

        if (debuff[1]) {
            poisonTimer -= 1 * Time.deltaTime;
        } else if (!debuff[1]) {
            poisonTimer = poisonTimerBase;
        }

        if (debuff[0]) {
            walkingSpeed = walkingSpeedDecreased;
            slowTimer = -1 * Time.deltaTime;
        } else if (!debuff[0]) {
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

        //This checkes if there are any enemies within range.
        if (towerRef.state == TowerHandler.Team.teamOne && state == Team.teamTwo) {
            if (!towerRef.targets.Contains(gameObject)) {
                towerRef.targets.Add(gameObject);
            }
        }

        if (towerRef.state == TowerHandler.Team.teamTwo && state == Team.teamOne && !towerRef.targets.Contains(gameObject)) {
            towerRef.targets.Add(gameObject);
        }
    }

    public void OnTriggerStay(Collider other) {

        if (other.GetComponent<TowerHandler>().state == TowerHandler.Team.teamOne && state == Team.teamTwo) {
            if (health < 1) {
                other.GetComponent<TowerHandler>().targets.Remove(thisObject);
            }
        }

        if (other.GetComponent<TowerHandler>().state == TowerHandler.Team.teamTwo && state == Team.teamOne) {
            if (health < 1) {
                other.GetComponent<TowerHandler>().targets.Remove(thisObject);
            }
        }
    }


    public void OnTriggerExit(Collider other) {

        if (other.GetComponent<TowerHandler>().state == TowerHandler.Team.teamOne && state == Team.teamTwo) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject);
        }

        if (other.GetComponent<TowerHandler>().state == TowerHandler.Team.teamTwo && state == Team.teamOne) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject);
        }
    }
}
