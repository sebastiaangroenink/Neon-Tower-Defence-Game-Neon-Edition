using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsHandler : MonoBehaviour {

    public enum Team {teamOne, teamTwo}
    public Team state;

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
    public List<float> debuffTimerBase = new List<float>();
    public List<float> debuffTimer = new List<float>();
    public List<GameObject> target = new List<GameObject>();

    public void Start() {
        thisObject = gameObject;
    }

    void Update() {
        if(health <=0) {
            Destroy(gameObject);
        }

        gameTick -= 1 * Time.deltaTime;

        if (gameTick < 0) {
            if (debuff[0])
            {
                walkingSpeed = walkingSpeedDecreased;
            }
            else
            {
                walkingSpeed = walkingSpeedRegular;
            }

            if (debuff[1]) {
                health = -1;
            }

            if (debuff[2]) {
                health = -5;
            }
            gameTick = 1;
        }
        for(int i =0; i < debuffTimer.Count; i++)
        {
            if(debuffTimer[i] < 0)
            {
                debuff[i] = false; //slow[0] poison[1] incendiary[2] timers need to be added.
                debuffTimer[i] = debuffTimerBase[i];
            }
        }

        if (debuff[0])
        {
            debuffTimer[0] -= 1 * Time.deltaTime;
        }
        else
        {
            walkingSpeed = walkingSpeedRegular;
            slowTimer = debuffTimerBase[0];
        }

        if (debuff[1]) {
            debuffTimer[1] -= 1 * Time.deltaTime;
        }
        else{
            poisonTimer = debuffTimerBase[1];
        }

        transform.position = Vector3.MoveTowards(transform.position, target[index].transform.position, walkingSpeed);

        if (debuff[2])
        {
            debuffTimer[2] -= 1 * Time.deltaTime;
        }
        else
        {
            incendiaryTimer = debuffTimerBase[2];
        }

        if (transform.position != target[target.Count].transform.position) {
            if (transform.position == target[index].transform.position) {
                index++;
            }
        }
        else
        {
            canAttackCastle = true;
        }
    }

    public void OnTriggerEnter(Collider other) {
        other.GetComponent<TowerHandler>().targets.Add(thisObject);
    }

    public void OnTriggerStay(Collider other) {
        if(health <=0) {
            other.GetComponent<TowerHandler>().targets.Remove(thisObject); //Is dit echt nodig?
        }
    }

    public void OnTriggerExit(Collider other) {
        other.GetComponent<TowerHandler>().targets.Remove(thisObject);
    }
}
