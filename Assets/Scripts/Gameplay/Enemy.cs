using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{

    public abstract class Enemy : MonoBehaviour, IKillable
    {
        public abstract int _hitPoints { get; }
       
     
        public abstract int _scorePerKill { get; }
      

        public abstract void TakeDamage(int damage);
             
    }
}