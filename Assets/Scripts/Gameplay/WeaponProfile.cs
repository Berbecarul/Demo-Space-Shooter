using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "WeaponProfile", menuName = "Custom Assets/Weapon Profile")]
    public class WeaponProfile : ScriptableObject
    {
        [Header("Properties")]
        public float reloadTime = 0.5f;
        public GameObject projectilePrefab;

    }

}