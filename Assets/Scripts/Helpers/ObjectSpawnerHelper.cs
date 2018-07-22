using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Helper
{
    public class ObjectSpawnerHelper : MonoBehaviour
    {


        public void SpawnThatHere(GameObject prefab)
        {
            prefab.PooledSpawn(transform.position, transform.rotation);

        }

    }

}