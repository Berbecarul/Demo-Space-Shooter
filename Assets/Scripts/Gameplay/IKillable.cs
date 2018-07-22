using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public interface IKillable
    {
        int _hitPoints { get; }
        void TakeDamage(int damage);
    }

}