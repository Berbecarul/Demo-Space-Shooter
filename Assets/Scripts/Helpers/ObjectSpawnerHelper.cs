using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Helper
{
    public class ObjectSpawnerHelper : MonoBehaviour
    {


        public GameObject SpawnThatHere(GameObject prefab)
        {
            return prefab.PooledSpawn(transform.position, transform.rotation);

        }

    }

}