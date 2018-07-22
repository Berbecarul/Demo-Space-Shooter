using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{

    public class Player : MonoBehaviour
    {
        public static Player _instance { get; protected set; }

        [Header("Properties")]
        public float maxSpeed = 10;

        [Header("Events")]
        public UnityEvent onDeath;

        [Header("References")]
        public Rigidbody rb;

        Vector3 movementVector;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
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

    }

}