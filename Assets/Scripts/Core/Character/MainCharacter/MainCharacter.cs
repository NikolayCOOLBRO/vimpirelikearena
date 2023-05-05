using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters
{
    public class MainCharacter : MonoBehaviour, IIniting, ITakingDamage
    {
        [SerializeField] private Transform m_WeaponPoint;

        [SerializeField] private float m_SafeTime;
        [SerializeField] private bool m_TakeDamage;

        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;

        public Transform WeaponPoint => m_WeaponPoint;

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
            if (!m_TakeDamage)
            {
                return;
            }

            m_TakeDamage = false;

            Debug.Log("I take Damage");

            StartCoroutine(TakeDamageCoroutine());
        }

        private IEnumerator TakeDamageCoroutine()
        {
            yield return new WaitForSeconds(m_SafeTime);
            m_TakeDamage = true;
        }
    }
}