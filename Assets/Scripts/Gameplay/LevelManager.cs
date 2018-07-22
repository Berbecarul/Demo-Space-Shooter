using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Gameplay {

    public class LevelManager : MonoBehaviour
    {
        [Header("Playable Space Management")]
        public float width = 6;
        public float length = 8;

        [Header("Wave Management")]
        public WaveManagementProfile spawnerProfile;

        [Header("References")]
        public GameObject playerPrefab;
        public Transform playerSpawnPoiint;
        public Transform enemySpawnPoint;
        public MeshCollider rightCollider;
        public MeshCollider leftCollider;
   

        private void Awake()
        {
            BoundsInitialisation();
             
        }

        private void Start()
        {
            if (playerPrefab != null)
            {
                //place player here
                playerPrefab.PooledSpawn(playerSpawnPoiint.position, playerSpawnPoiint.rotation);
            }
            else
                Debug.LogWarning(this + "No player prefab here!");

            StartCoroutine(spawnerProfile.SpawnerRoutine(enemySpawnPoint));

        }


        void BoundsInitialisation()
        {
            //orientation
            rightCollider.transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            leftCollider.transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);

            //size
            rightCollider.transform.localScale = new Vector3(1, 0, 0) * length + new Vector3(0, 1);
            leftCollider.transform.localScale = new Vector3(1, 0, 0) * length + new Vector3(0, 1);

            //position
            rightCollider.transform.position = transform.position + Vector3.left * width * 0.5f;
            leftCollider.transform.position = transform.position + Vector3.right * width * 0.5f;

        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, 0.1f, length));

        }

    }
}