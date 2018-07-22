using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using BackEnd;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "WaveManagementProfile", menuName = "Custom Assets/Wave Management Profile")]
    public class WaveManagementProfile : ScriptableObject
    {
        [Header("Spawnable Enemy ")]
        public List<GameObject> enemies;

        [Header("Endless Wave Management")]
        public float maxSpawnDelay = 1;
        public float minSpawnDelay = 0.05f;
        public float delayDecreaseVelocity = 0.2f;
        public float spawnArc = 90;



        public IEnumerator SpawnerRoutine(Transform spawnPoint)
        {
            float delay = maxSpawnDelay;
            
            yield return new WaitUntil(() => Input.GetButtonDown("Fire"));

            Events.InvokeWaveStarted();

            while (Player._instance._hitPoints > 0)
            {
				 
                SpawnRandomEnemy(spawnPoint);
                yield return new WaitForSeconds(delay);
				delay = Mathf.Clamp (delay -= Time.deltaTime, minSpawnDelay, maxSpawnDelay);
            }

            yield return new WaitForSeconds(3);

            GameManager.RestartLevel();

            yield return null;
        }

        void SpawnRandomEnemy(Transform spawnPoint)
        {
            spawnPoint.rotation = 
            Quaternion.AngleAxis(-180 + Random.Range(-spawnArc * 0.5f, spawnArc* 0.5f),Vector3.up);

            enemies[Random.Range(0,enemies.Count)].PooledSpawn(spawnPoint.position,spawnPoint.rotation);


        }

    }
     
}