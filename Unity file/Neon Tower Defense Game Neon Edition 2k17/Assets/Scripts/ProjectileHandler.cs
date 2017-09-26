using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public TroopsHandler troopReference;
    public enum Team { teamOne, teamTwo }
    public Team state;

    public Vector3 target;

    public int damage;

    public float projectileSpeed;

    public List<bool> debuffs = new List<bool>();

    public void Start() {
        StartCoroutine(SelfDestruction(5));
    }

    public void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed);
        transform.rotation = Quaternion.LookRotation(transform.position, target);
    }

    public IEnumerator SelfDestruction(float time) {
        while (true) {
            yield return new WaitForSeconds(time);
            print("Targed missed, Initiating self destruction.");
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision c) {
        troopReference = c.transform.GetComponent<TroopsHandler>();

        if (c.transform.GetComponent<TroopsHandler>() != null) {
            if (troopReference.state == TroopsHandler.Team.teamOne && state == Team.teamTwo) {
                troopReference.debuff = debuffs;
                troopReference.health = troopReference.health - damage;
                Destroy(gameObject);
                print("Damage done: " + damage);
                print("Enemy health left: " + troopReference.health);
            }
        }

        if (c.transform.GetComponent<TroopsHandler>() != null) {
            if (troopReference.state == TroopsHandler.Team.teamTwo && state == Team.teamOne) {
                troopReference.debuff = debuffs;
                troopReference.health = troopReference.health - damage;
                Destroy(gameObject);
                print("Damage done: " + damage);
                print("Enemy health left: " + troopReference.health);
            }
        }
    }
}
