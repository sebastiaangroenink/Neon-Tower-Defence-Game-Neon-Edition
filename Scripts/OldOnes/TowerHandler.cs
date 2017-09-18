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

    public enum team {teamOne, teamTwo}
    public team state;

    public bool isTroop;

    private bool isTeamOne;
    private bool isTeamTwo;

    public Material towerSkin;
    [Tooltip("This is the skin of the tower:")]

    public SphereCollider ArealEffect;

    public GameObject projectile;
    public GameObject target;

    public void Awake() {
        GetComponent<Renderer>().material = towerSkin;

        if(state == team.teamOne) {
            isTeamOne = true;
        }

        if(state == team.teamTwo) {
            isTeamTwo = true;
        }
    }

    public void Update() {
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

        if(debuff[3] == true && healingCoolDown == 0) {
        if(c.transform.GetComponent<TroopsHandler>().state == TroopsHandler.team.teamOne && state == team.teamOne && isTroop == true) {
            c.transform.GetComponent<TroopsHandler>().health += healingAmount;
            print("Healing TeamOne Members within range!");
            healingCoolDown = healingCoolDownBase;
        }

            if (c.transform.GetComponent<TroopsHandler>().state == TroopsHandler.team.teamTwo && state == team.teamTwo && isTroop == true) {
                c.transform.GetComponent<TroopsHandler>().health += healingAmount;
                print("Healing TeamTwo Members within range!");
                healingCoolDown = healingCoolDownBase;
            }
        }
    }

    public void FiringProjectile() {
        if (isTeamOne == true) {
            Instantiate(projectile, transform.position, target.transform.rotation);
            projectile.GetComponent<ProjectileHandler>().debuffs = debuff;
            projectile.GetComponent<ProjectileHandler>().damage = damage;
            projectile.GetComponent<ProjectileHandler>().state = ProjectileHandler.team.teamOne;
            projectile.GetComponent<ProjectileHandler>().target = targets[index].transform.position;
            projectile.GetComponent<ProjectileHandler>().projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
        }

        if (isTeamTwo == true) {
            Instantiate(projectile, transform.position, target.transform.rotation);
            projectile.GetComponent<ProjectileHandler>().debuffs = debuff;
            projectile.GetComponent<ProjectileHandler>().damage = damage;
            projectile.GetComponent<ProjectileHandler>().state = ProjectileHandler.team.teamTwo;
            projectile.GetComponent<ProjectileHandler>().target = targets[index].transform.position;
            projectile.GetComponent<ProjectileHandler>().projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
        }
    }
}
