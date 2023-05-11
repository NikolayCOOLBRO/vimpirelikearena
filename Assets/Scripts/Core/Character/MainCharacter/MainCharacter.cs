using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters
{
    public class MainCharacter : GameCharacterBehaviour, IHero
    {
        [SerializeField] private Transform m_WeaponPoint;

        [SerializeField] private float m_SafeTime;
        [SerializeField] private bool m_TakeDamage;

        public Transform WeaponPoint => m_WeaponPoint;

        public void Move(Vector2 deriction)
        {
            m_Moving.Move(new Vector3(deriction.x, 0f, deriction.y), CharacterData.Speed, transform);
        }

        public override void TakeDamage(int damage)
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