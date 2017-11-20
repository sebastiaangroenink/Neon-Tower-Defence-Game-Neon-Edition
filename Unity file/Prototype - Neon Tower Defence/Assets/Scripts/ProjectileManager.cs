using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : TowerPresets {

    public Transform target;

    private void Start()
    {
        
    }
    public void Update()
    {
        if (target != null)
        {
            // transform.position = Vector3.MoveTowards(transform.position,target.position*Time.deltaTime*projectileSpeed);
            print("flies to enemy");
        }
        else
        {
        //    Destroy(transform);
        }
    }

    public void Called(int towerType)
    {

        if (towerType == 1)
        {
            damage = 1.0f;
            projectileSpeed = 2.0f;
            fire = true;
        }

        if (towerType == 2)
        {
            damage = 5.0f;
            projectileSpeed = 0.6f;
            slow = true;
            fire = true;
        }
        if (towerType == 3)
        {
            damage = 0.6f;
            projectileSpeed = 8.0f;

        }
        if (towerType == 4)
        {
            damage = 12f;
            projectileSpeed = 3.0f;
            toxic = true;
            slow = true;
        }
    }
}
