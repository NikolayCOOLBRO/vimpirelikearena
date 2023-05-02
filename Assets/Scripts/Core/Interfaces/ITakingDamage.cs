using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core
{
    public interface ITakingDamage
    {
        event Action OnTakeDamage;

        event Action OnDead;

        void TakeDamage(int damage);
    }
}