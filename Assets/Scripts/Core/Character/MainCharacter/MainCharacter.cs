using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters
{
    public class MainCharacter : MonoBehaviour, IIniting, ITakingDamage
    {
        [SerializeField] private Transform m_WeaponPoint;

        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;

        public void Init()
        {
            m_CharacterData = new CharacterData()
            {
                Speed = 7f,
                HealthPoints = 100
            };
            m_CharacterMovement = new CharacterMovement();
        }

        public void Move(Vector2 deriction)
        {
            m_CharacterMovement.Move(new Vector3(deriction.x, 0f, deriction.y), m_CharacterData.Speed, transform);
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("I take Damage");
        }
    }
}