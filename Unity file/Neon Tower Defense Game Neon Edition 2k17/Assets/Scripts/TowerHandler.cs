using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHandler : MonoBehaviour {

    public static int baseAttackSpeed = 10;

    public string name;

    public string Description;

    public int sellPrice;
    [Tooltip("Sellprice of a tower:")]

    public int damage;

    private int index;

    public bool canAttack;

    public float arialRangeScale;

    private float projectileInterval;

    public float projectileIntervalBase;
    public float projectileSpeed;

    [Tooltip("The indexes in the debuff list are as following: [0] = Slow, [1] = Poison, [2] = Fire Damage, [3] = Heal Ability.")]
    public List<bool> debuff = new List<bool>();

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> allies = new List<GameObject>();

    public ProjectileHandler projectileReference;
    public TroopsHandler troopRef;

    public enum Team { teamOne, teamTwo }
    public Team state;

    private bool isTeamOne;
    private bool isTeamTwo;

    public Material towerSkin;
    [Tooltip("This is the skin of the tower:")]

    public SphereCollider ArealEffect;

    public GameObject projectile;

    public void Awake() {
        projectileInterval = projectileIntervalBase;

        ArealEffect = gameObject.GetComponent<SphereCollider>();

        if (state == Team.teamOne) {
            isTeamOne = true;
        }

        if (state == Team.teamTwo) {
            isTeamTwo = true;
        }
    }

    public void Update() {
        index = Random.Range(0, targets.Count - 1);

        for (int i = 1; i <= targets.Count - 1; i++) {
            if (targets[i] == null)
                targets.RemoveAt(i);
        }


        ArealEffect.radius = arialRangeScale;

        if (projectileInterval != 0) {
            projectileInterval -= 1 * Time.deltaTime;
        }

        if (projectileInterval < 0) {
            projectileInterval = 0;
        }

        if (projectileInterval == 0 && canAttack) {
            for (int i = 0; i < targets.Count; i++) {
                if (targets[i] != null)
                    FiringProjectile();
                projectileInterval = projectileIntervalBase;
            }
        }
    }

    public void FiringProjectile() {
        GameObject projectileTower = projectile;
        projectileInterval = projectileIntervalBase;

        if (isTeamOne == true) {
            Instantiate(projectileTower, transform.position, Quaternion.identity);
            projectileReference.debuffs = debuff;
            projectileReference.damage = damage;
            projectileReference.state = ProjectileHandler.Team.teamOne;
            projectileReference.target = targets[index].transform.position;
            projectileReference.projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
            print("Shooting missle harmful to team Two");
        }

        if (isTeamTwo == true) {
            Instantiate(projectileTower, transform.position, Quaternion.identity);
            projectileReference.debuffs = debuff;
            projectileReference.damage = damage;
            projectileReference.state = ProjectileHandler.Team.teamTwo;
            projectileReference.target = targets[index].transform.position;
            projectileReference.projectileSpeed = projectileSpeed;
            projectileInterval = projectileIntervalBase;
            print("Shooting missle harmful to team one");
        }
    }
}
