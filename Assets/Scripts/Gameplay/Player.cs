using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{

    public class Player : MonoBehaviour,IKillable
    {
        public static Player _instance { get; protected set; }

        public int _hitPoints
        {
            get
            {
                return startingHp;
            }
        }

        [Header("Properties")]
        public float maxSpeed = 10;
        public int startingHp = 10;

        [Header("Events")]
        public UnityEvent onDeath;

        [Header("References")]
        public Rigidbody rb;

        Vector3 movementVector;
        int currentHp;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void OnEnable()
        {
            SelfReset();
        }

        private void Update()
        {
            //get input
            movementVector.x = Input.GetAxisRaw("Horizontal");

            //movementVector.z = Input.GetAxisRaw("Vertical");

            movementVector = movementVector.normalized* 
                Mathf.Clamp01(movementVector.magnitude) * maxSpeed;

            //update rigidbody velocity
            rb.velocity = movementVector;
        }

        void SelfReset()
        {
            currentHp = startingHp;
            Events.InvokePlayerHpUpdate(currentHp);
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            Events.InvokePlayerHpUpdate(currentHp);
        }
    }

}