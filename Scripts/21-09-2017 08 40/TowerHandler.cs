using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHandler : MonoBehaviour {

    public static int baseAttackSpeed = 10;

    public string name;

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

    [Tooltip("The indexes in the debuff list are as following: [0] = Slow, [1] = Poison, [2] = Fire Damage, [3] = Heal Ability.")]
    public List<bool> debuff = new List<bool>();

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> allies = new List<GameObject>();

    public ProjectileHandler projectileReference;
    public TroopsHandler troopRef;

    public enum team { teamOne, teamTwo }
    public team state;

    public bool isTroop;

    private bool isTeamOne;
    private bool isTeamTwo;

    public Material towerSkin;
    [Tooltip("This is the skin of the tower:")]

    public SphereCollider ArealEffect;

    public GameObject projectile;

    public void Awake() {
        projectileReference = projectile.GetComponent<ProjectileHandler>();
        GetComponent<Renderer>().material = towerSkin;

        if (state == team.teamOne) {
            isTeamOne = true;
        }

        if (state == team.teamTwo) {
            isTeamTwo = true;
        }
    }

    public void Update() {
        index = Random.Range(0, targets.Count - 1);

        if (debuff[3] == true && healingCoolDown == 0) {
            for (int i = 0; i <= allies.Count - 1; i++) {
                troopRef = allies[i].GetComponent<TroopsHandler>();
                troopRef.health = troopRef.health +healingAmount;
                print("Healed allie named: " + allies[i].name + " for " + healingAmount + ".");
                print("The allie called: " + troopRef.name + " now has a total health of: " + troopRef.health);
            }

            healingCoolDown = healingCoolDownBase;
        }

        for (int i = 1; i <= targets.Count -1; i++) {
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
            for (int i = 0; i < targets.Count; i++) {
                if(targets[i] != null) 
                FiringProjectile();
            }
        }
    } 

    public void FiringProjectile() {
        GameObject projectileTower = projectile;

        if (isTeamOne == true) {
            Instantiate(projectileTower, transform.position, Quaternion.identity);
            projectileReference.debuffs = debuff;
            projectileReference.damage = damage;
            projectileReference.state = ProjectileHandler.team.teamOne;
            projectileReference.target = targets[index].transform.position;
            projectileReference.projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
            print("Shooting missle harmful to team Two");
        }

        if (isTeamTwo == true) {
            Instantiate(projectileTower, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileHandler>().debuffs = debuff;
            projectileReference.damage = damage;
            projectileReference.state = ProjectileHandler.team.teamTwo;
            projectileReference.target = targets[index].transform.position;
            projectileReference.projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
            print("Shooting missle harmful to team one");
        }
    }
}
