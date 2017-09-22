using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHandler : MonoBehaviour {

    public static int baseAttackSpeed = 10;

    public string name;
    [Tooltip("The indexes in the debuff list are as following: [0] = Slow, [1] = Poison, [2] = Fire Damage, [3] = Heal Ability.")]

    public string Description;

    public int price;
    [Tooltip("Cost of a tower:")]

    public int health;
    public int damage;
    public int speed;
    public int attackSpeed;
    public int healingAmount;

    private int index;

    public bool canAttack;

    public float arialRangeScale;

    public float projectileInterval;
    public float projectileIntervalBase;
    public float projectileSpeed;

    public float healingCoolDownBase;
    public float healingCoolDown;

    public List<bool> debuff = new List<bool>();
    public List<GameObject> targets = new List<GameObject>();

    public enum Team {teamOne, teamTwo}
    public Team state;

    public bool isTroop;

    private bool isTeamOne;
    private bool isTeamTwo;

    public SphereCollider ArealEffect;

    public GameObject projectile;
    public GameObject target;

    public void Awake() {

        if(state == Team.teamOne) {
            isTeamOne = true;
        }

        if(state == Team.teamTwo) {
            isTeamTwo = true;
        }
    }

    public void Update() {
        for (int i = 1; i <= targets.Count; i++) {
            if (targets[i] == null)
                targets.RemoveAt(i);
        }

        ArealEffect.radius = arialRangeScale;

        if (healingCoolDown != 0) {
            healingCoolDown -= 1 * Time.deltaTime;
        }

        if (projectileInterval != 0) {
            projectileInterval -= 1 * Time.deltaTime;
        }

        if(projectileInterval < 0) {
            projectileInterval = 0;
        }

        if (healingCoolDown < 0) {
            healingCoolDown = 0;
        }

        if(projectileInterval == 0 ) {
            for (int i = 1; i <= targets.Count; i++) {
                if(targets[i] != null) 
                FiringProjectile();
            }
        }
    }

    public void OnCollisionEnter(Collision c) {
        index = Random.Range(0, targets.Count);

        if (debuff[3] && healingCoolDown == 0 && isTroop)
        {

            healingCoolDown = healingCoolDownBase;

            if (state == Team.teamOne && c.transform.GetComponent<TroopsHandler>().state == TroopsHandler.Team.teamOne)
            {
                c.transform.GetComponent<TroopsHandler>().health += healingAmount;
                print("Healing TeamOne Members within range!");
            }
            else if (state == Team.teamTwo && c.transform.GetComponent<TroopsHandler>().state == TroopsHandler.Team.teamTwo)
            {
                c.transform.GetComponent<TroopsHandler>().health += healingAmount;
                print("Healing TeamTwo Members within range!");
            }
        }
    }

    public void FiringProjectile() {
        Instantiate(projectile, transform.position, target.transform.rotation);
        projectile.GetComponent<ProjectileHandler>().debuffs = debuff;
        projectile.GetComponent<ProjectileHandler>().damage = damage;
        projectile.GetComponent<ProjectileHandler>().state = ProjectileHandler.Team.teamOne;
        projectile.GetComponent<ProjectileHandler>().target = targets[index].transform.position;
        projectile.GetComponent<ProjectileHandler>().projectileSpeed = projectileSpeed;
        projectileInterval = projectileIntervalBase;

        if (isTeamOne)
        {
            projectile.GetComponent<ProjectileHandler>().state = ProjectileHandler.Team.teamOne;
        }
        else if (isTeamTwo)
        {
            projectile.GetComponent<ProjectileHandler>().state = ProjectileHandler.Team.teamTwo;
        }
    }
}
