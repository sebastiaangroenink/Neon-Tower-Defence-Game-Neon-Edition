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
    }

    public void OnCollisionEnter(Collision c) {
        if(troopReference.state == TroopsHandler.team.teamOne && state == team.teamTwo) {
            c.transform.GetComponent<TroopsHandler>().debuff = debuffs;
            c.transform.GetComponent<TroopsHandler>().health = -damage;
            Destroy(gameObject);
        }
        if (troopReference.state == TroopsHandler.team.teamTwo && state == team.teamOne) {
            c.transform.GetComponent<TroopsHandler>().debuff = debuffs;
            c.transform.GetComponent<TroopsHandler>().health = -damage;
            Destroy(gameObject);
        }
    }
}
