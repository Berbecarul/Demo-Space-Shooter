using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Gameplay {

    public class PlayerWeapon : MonoBehaviour {


        [Header("Properties")]
        public WeaponProfile weapon;

        [Header("References")]
        public Transform firePoint;

        float reloadRemainig = 0;
         
        private void OnEnable()
        {
            if (weapon == null)
            {
                Debug.LogWarning("No weapon profile here" + gameObject.name);
                this.enabled = false;
            }
        }

        private void Update()
        {
            //reloading;
            if (reloadRemainig <= 0)
            {
                if (Input.GetButton("Fire"))
                    FireTheWeapon();
            }
            else
                reloadRemainig -= Time.deltaTime;


        }


        public void FireTheWeapon()
        {
            reloadRemainig = weapon.reloadTime;

            weapon.projectilePrefab.PooledSpawn(firePoint.position, firePoint.rotation);

        }

    }

}