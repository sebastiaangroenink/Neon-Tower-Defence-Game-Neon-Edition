using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    //requests towerPreset from TowerPreset to set variables
    public TowerPresets towerPreset;

    //tower's projectile
    public GameObject projectile;

    //attack speed
    public float AttackSpeed;

    //sell price of tower
    public int sellPrice;

    //projectile interval
    public float canShoot;

    //index of enemies
    public int index;

    //AOE range
    public float areaOfeffectRange;

    public SphereCollider range;





    //checks if tower is enabled
    public bool isEnabled;


    //List of enemies
    public List<GameObject> enemies = new List<GameObject>();

    public void Start()
    {
        transform.GetComponent<TowerManager>().enabled = false;

        towerPreset = GameObject.Find("TowerPresets").GetComponent<TowerPresets>();
    }

    public void Update()
    {
        {
            
            if (isEnabled)
            {

                canShoot -= AttackSpeed * Time.deltaTime;

                if (canShoot <= 0.0f)
                {
                    //shoot
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    canShoot = 1.0f;
                    print("works");
                }
            }
        }
    }


   public void FirstSpawned(int towerPresetNumber)
    {
        towerPreset.towerManager = transform.GetComponent<TowerManager>();
        towerPreset.Called(towerPresetNumber);
        isEnabled = true;
    }
}
