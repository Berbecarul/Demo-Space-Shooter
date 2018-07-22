using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Helper
{

    public class SpawnedObjectHelper : MonoBehaviour
    {
        [Header("Properties")]
        public float despawnTime = 1;
       
        float timeLeft;

        private void OnEnable()
        {
            SelfReset();
        }

        private void Update()
        {
            if (timeLeft <= 0)
                DespawnThis();
            else
                timeLeft -= Time.deltaTime;
        }
  
        public void DespawnThis()
        {
            gameObject.PooledDespawn();
        }


        void SelfReset()
        {
            timeLeft = despawnTime;

        }

    }

}