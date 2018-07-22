using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    [RequireComponent(typeof(Rigidbody))]
    public class BounceHelper : MonoBehaviour
    {
        [Header("Properties")]
        public string[] bouncyTags;

        [Header("References")]
        public Collider bouncyCollider;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if (bouncyCollider == null || rb == null)
            {
                this.enabled = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            
            for (int i = 0; i < bouncyTags.Length; i++)
            {
            
                if (collision.collider.CompareTag(bouncyTags[i]))
                {
                    Bounce(collision);

                }
                 
            }
        }
 
     

        void Bounce(Collision collision)
        {

            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflection = rb.velocity.normalized + normal.normalized;

            rb.velocity = reflection * rb.velocity.magnitude;

        }

    }



}

 