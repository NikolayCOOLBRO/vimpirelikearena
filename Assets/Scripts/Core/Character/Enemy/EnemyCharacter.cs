using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemyCharacter : MonoBehaviour, ITakingDamage
    {
        [SerializeField] private Weapon m_Weapon;

        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;

        private bool m_IsMove;

        public void Init()
        {
            m_CharacterData = new CharacterData()
            {
                Speed = 3f
            };
            m_CharacterMovement = new EnemyMovement();
        }

        public void Move(IAttaching targetPosition)
        {
            if (m_IsMove)
            {
                return;
            }

            StartCoroutine(MoveCoroutine(targetPosition));
        }

        public void Rotate(Vector3 angle)
        {
            transform.eulerAngles = angle;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Enemy take Damage");
        }

        private IEnumerator MoveCoroutine(IAttaching targetPosition)
        {
            while (gameObject.activeInHierarchy)
            {
                m_IsMove = true;
                m_CharacterMovement.Move(targetPosition.GetTarget().position, m_CharacterData.Speed * Time.deltaTime, transform);
                yield return null;
            }

            m_IsMove = false;

            yield break;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<ITakingDamage>(out var takingDamage))
            {
                takingDamage.TakeDamage(10);
            }
        }
    }
}