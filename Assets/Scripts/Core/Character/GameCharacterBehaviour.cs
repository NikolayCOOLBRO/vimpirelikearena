using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Characters
{

    public abstract class GameCharacterBehaviour : MonoBehaviour, ITakingDamage, IRepelled, IIniting
    {
        public event Action<GameCharacterBehaviour> OnTakeDamage;

        private int m_CurrentHealthPoint;
        public int CurrentHealthPoint => m_CurrentHealthPoint;

        private CharacterData m_CharacterData;
        public CharacterData CharacterData => m_CharacterData;

        protected IMoving m_Moving;

        public void SetCharacterData(CharacterData characterData)
        {
            m_CharacterData = characterData;
        }

        public void SetCharacterMovement(IMoving moving)
        {
            m_Moving = moving;
        }

        public virtual void Init()
        {
            m_CurrentHealthPoint = m_CharacterData.HealthPoints;
        }

        public void Push(Vector3 direction ,float force)
        {
            if (TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddForce(direction * force, ForceMode.Force);
            }
        }

        public virtual void TakeDamage(int damage)
        {
            m_CurrentHealthPoint -= damage;
            OnTakeDamage?.Invoke(this);

            if (m_CurrentHealthPoint <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Debug.LogError(gameObject.name + " - I dead.");
        }
    }
}