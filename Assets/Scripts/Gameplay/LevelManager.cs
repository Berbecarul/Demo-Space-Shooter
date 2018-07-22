using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

namespace Gameplay {

    public class LevelManager : MonoBehaviour
    {
        [Header("Playable Space Management")]
        public float width = 5;
        public float length = 8;

        [Header("Wave Management")]
        public WaveManagementProfile spawnerProfile;

        [Header("References")]
        public GameObject playerPrefab;
        public Transform playerSpawnPoiint;
        public Transform enemySpawnPoint;
        public MeshCollider rightCollider;
        public MeshCollider leftCollider;
		public LineRenderer lineLeft;
		public LineRenderer lineRight;


		int score = 0;

        private void Awake()
        {
            BoundsInitialisation();
			LineRendererInit ();


			Events._onWaveStarted += Events__onWaveStarted;
			Events._onEnemyKilled+= Events__onEnemyKilled;
        }

        void Events__onWaveStarted ()
        {
			if (playerPrefab != null)
			{
				//place player here
				playerPrefab.PooledSpawn(playerSpawnPoiint.position, playerSpawnPoiint.rotation);
			}
			else
				Debug.LogWarning(this + "No player prefab here!");
        }

        void Events__onEnemyKilled (Enemy obj)
        {
			score += obj._scorePerKill;
			Events.InvokeScoreUpdate (score);
        }

        private void Start()
        {
          
			Events.InvokeScoreUpdate (score);

            StartCoroutine(spawnerProfile.SpawnerRoutine(enemySpawnPoint));

        }

		void LineRendererInit()
		{
			lineLeft.positionCount = 2;
			lineLeft.SetPosition (0, transform.position + new Vector3 (width * 0.5f,0, length * 0.5f));
			lineLeft.SetPosition (1, transform.position + new Vector3 (width * 0.5f,0, -length * 0.5f));

			lineRight.positionCount = 2;
			lineRight.SetPosition (0, transform.position + new Vector3 (-width * 0.5f,0, length * 0.5f));
			lineRight.SetPosition (1, transform.position + new Vector3 (-width * 0.5f,0, -length * 0.5f));



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

		private void OnDestroy()
		{
			Events._onEnemyKilled -= Events__onEnemyKilled;
			Events._onWaveStarted -= Events__onWaveStarted;

		}


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, 0.1f, length));

        }

    }
}