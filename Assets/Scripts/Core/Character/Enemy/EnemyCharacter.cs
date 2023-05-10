using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemyCharacter : GameCharacterBehaviour, INeedingWeapon, INeeding<IAttaching>
    {
        [SerializeField] private Transform m_WeaponPoint;
        [SerializeField] private WeaponType m_WeaponType;

        private CharacterWeapon m_CharacterWeapon;
        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;
        private IAttaching m_Attaching;

        private bool m_IsMove;

        public WeaponType GetWeaponType()
        {
            return m_WeaponType;
        }

        public void Init()
        {
            m_CharacterData = new CharacterData()
            {
                Speed = 3f
            };
            m_CharacterMovement = new EnemyMovement();
            m_CharacterWeapon.Init();
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

        public void Set(WeaponBehaviour generic)
        {
            generic.gameObject.layer = 9;//TODO
            if (m_CharacterWeapon == null)
            {
                m_CharacterWeapon = new CharacterWeapon();
                m_CharacterWeapon.Set(m_Attaching);
            }

            m_CharacterWeapon.AddWeapon(generic);
        }

        public void Set(IAttaching generic)
        {
            m_Attaching = generic;
        }

        public Transform Where()
        {
            return m_WeaponPoint;
        }

        public void StartShoot()
        {
            m_CharacterWeapon.Start();
        }

        public void StopShoot()
        {
            m_CharacterWeapon.Stop();
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
    }
}