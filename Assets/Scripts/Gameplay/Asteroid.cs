using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{

    public class Asteroid : Enemy
    {
        [Header("Properties")]
        
        public int startingHp = 10;
        public int scorePerKill = 1;

        public UnityEvent onDeath;

        [Header("References")]
        public Rigidbody rb;

        public override int _hitPoints => currentHp; 
        public override int _scorePerKill => scorePerKill;

        int currentHp;

        private void OnEnable()
        {
            SelfReset();
        }
		 
        void SelfReset()
        {
            currentHp = startingHp;
            rb.velocity = Vector3.zero;
        }

        public override void TakeDamage(int damage)
        {
            currentHp -= damage;
			if (currentHp <= 0)
			{
				onDeath.Invoke ();
				Events.InvokeEnemyKilled(this);
			}

        }

        
    }



}