using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPresets : MonoBehaviour {

    public TowerManager towerManager;


    //damage
    public float damage;

    //projectile speed 
    public float projectileSpeed;

    //projectiles
    public List<GameObject> projectileList = new List<GameObject>();

    //debuffs
    public bool toxic;
    public bool fire;
    public bool slow;
    public bool stun;
    public bool areaOfEffect;


    public void Called(int towerType)
    {

    if(towerType == 0)
        {
            towerManager.AttackSpeed = 2.0f;
            towerManager.sellPrice = 70;
            towerManager.range.radius = 5.0f;
            towerManager.projectile = projectileList[0];
        }

    if(towerType == 1)
        {
            towerManager.AttackSpeed = 1.0f;
            towerManager.sellPrice = 200;
            towerManager.range.radius = 5.0f;
            towerManager.projectile = projectileList[1];
        }
    if(towerType == 2)
        {
            towerManager.AttackSpeed = 4.0f;
            towerManager.sellPrice = 350;
            towerManager.range.radius = 5.0f;
            towerManager.projectile = projectileList[2];

        }
    if(towerType == 3)
        {
            towerManager.AttackSpeed = 0.5f;
            towerManager.sellPrice = 600;
            towerManager.range.radius = 5.0f;
            towerManager.projectile = projectileList[3];

        }
    }
}
