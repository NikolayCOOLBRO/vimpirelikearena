using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Characters
{

    public abstract class GameCharacterBehaviour : MonoBehaviour, ITakingDamage, IRepelled
    {
        private CharacterData m_CharacterData;
        public CharacterData CharacterData => m_CharacterData;

        public void Push(Vector3 direction ,float force)
        {
            if (TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddForce(direction * force, ForceMode.Force);
            }
        }

        public void TakeDamage(int damage)
        {
            
        }
    }
}