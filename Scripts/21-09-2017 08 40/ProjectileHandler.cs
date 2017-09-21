using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public TroopsHandler troopReference;
    public enum team {teamOne, teamTwo}
    public team state;

    public Vector3 target;

    public int damage;

    public float projectileSpeed;

    public List<bool> debuffs = new List<bool>();

    public void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed);
        transform.rotation = Quaternion.LookRotation(transform.position, target);
        if(transform.position == target) {
            Destroy(gameObject);
           print("Target Missed, initiaing self destruction...");
        }
    }

    public void OnCollisionEnter(Collision c) {
        troopReference = c.transform.GetComponent<TroopsHandler>();

        if (c.transform.GetComponent<TroopsHandler>() != null) {
            if (troopReference.state == TroopsHandler.team.teamOne && state == team.teamTwo) {
                troopReference.debuff = debuffs;
                troopReference.health = troopReference.health -damage;
                Destroy(gameObject);
                print("Damage done: " + damage);
                print("Enemy health left: " + troopReference.health);
            }
        }

        if (c.transform.GetComponent<TroopsHandler>() != null) {
            if (troopReference.state == TroopsHandler.team.teamTwo && state == team.teamOne) {
                troopReference.debuff = debuffs;
                troopReference.health = troopReference.health -damage;
                Destroy(gameObject);
                print("Damage done: " + damage);
                print("Enemy health left: " + troopReference.health);
            }
        }
    }
}
