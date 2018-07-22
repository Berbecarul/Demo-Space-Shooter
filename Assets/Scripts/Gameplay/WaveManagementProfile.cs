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



        public IEnumerator SpawnerRoutine(Transform spawnPoint)
        {

            yield return new WaitUntil(() => Input.GetButtonDown("Fire"));






            yield return null;
        }




    }

}