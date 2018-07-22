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
                return currentHp;
            }
        }

        [Header("Properties")]
        public float maxSpeed = 10;
        public int startingHp = 10;

        [Header("Events")]
        public UnityEvent onDeath;

        [Header("References")]
        public Rigidbody rb;
		public Animator anim;

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

			//anim update
			if(movementVector.x == 0)
				anim.SetInteger ("horizSpeed",0 );
         	else
				anim.SetInteger ("horizSpeed",movementVector.x >0 ? 1 : -1 );

            movementVector.x = movementVector.x*  maxSpeed;

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
			if (currentHp <= 0) 
			{
				currentHp = 0;
				onDeath.Invoke ();
		
			}
            Events.InvokePlayerHpUpdate(currentHp);
        }
    }

}