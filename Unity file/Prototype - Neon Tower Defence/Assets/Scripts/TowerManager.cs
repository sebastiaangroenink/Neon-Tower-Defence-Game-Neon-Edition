using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    //attack speed
    public float AttackSpeed;

    //projectile interval
    public float canShoot;
    //damage
    public float damage;

    //projectile speed 
    public float projectileSpeed;

    //projectiles
    public GameObject projectile;

    // script refences
    public ProjectileManager projectileManager;

    //debuffs
    public bool toxic;
    public bool fire;
    public bool slow;
    public bool stun;
    public bool areaOfEffect;

    //index of enemies
    public int index;

    //AOE range
    public float areaOfeffectRange;

    public SphereCollider range;

    //List of enemies
    public List<GameObject> enemies = new List<GameObject>();

    public void Update()
    {
        {
            canShoot -= AttackSpeed * Time.deltaTime;

            if(canShoot <= 0.0f)
            {
                //shoot
                Instantiate(projectile, transform.position, Quaternion.identity);
                projectileManager.towerManager = transform.GetComponent<TowerManager>();
            }
        }
    }
}
