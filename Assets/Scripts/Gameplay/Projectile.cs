using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
  
    public class Projectile : MonoBehaviour
    {
        [Header("Properties")]
        public string[] hostileTags;
        public int onHitDamage;
        public float speed;

		public UnityEvent onHit;


        [Header("References")]
        public Rigidbody rb;

        

        private void OnEnable()
        {
            rb.velocity = transform.forward * speed;
        }


        protected virtual void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < hostileTags.Length; i++)
            {
                if (other.CompareTag(hostileTags[i]))
                {
                    DealDamage(other.attachedRigidbody.GetComponent<IKillable>(), onHitDamage);
					onHit.Invoke ();
                }
            }
        }
         

        protected virtual void DealDamage(IKillable killable,int damage)
        {
            killable.TakeDamage(damage);
        }


    }


}

 