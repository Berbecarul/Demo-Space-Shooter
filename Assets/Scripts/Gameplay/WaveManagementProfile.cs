using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "WaveManagementProfile", menuName = "Custom Assets/Wave Management Profile")]
    public class WaveManagementProfile : ScriptableObject
    {
        [Header("Spawnable Enemy ")]
        public List<Enemy> enemies;

        [Header("Endless Wave Management")]
        public float maxSpawnDelay = 1;
        public float minSpawnDelay = 0.05f;
        public float delayDecreaseVelocity = 0.2f;



        public IEnumerator SpawnerRoutine(Transform spawnPoint)
        {
            float delay = 0;

            yield return new WaitUntil(() => Input.GetButtonDown("Fire"));



            while (Player._instance._hitPoints > 0)
            {

                yield return new WaitForSeconds(delay);
                delay -= Time.deltaTime;
            }



            yield return null;
        }

        void SpawnRandomEnemy()
        {


        }

    }
     
}