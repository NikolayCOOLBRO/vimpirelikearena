using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.Characters
{
    public class MainCharacterController : MonoBehaviour, IAttaching, IIniting, INeedingWeapon
    {
        [SerializeField] private MainCharacter m_MainCharacter;

        private CharacterWeapon m_CharacterWeapon;

        private IAttaching m_Attaching;

        public void SetAttaching(IAttaching attaching)
        {
            if (attaching == null)
            {
                Debug.LogError($"Class - {nameof(MainCharacterController)}:\n" +
                               $"Method - {nameof(SetAttaching)}. Null References - {nameof(attaching)}.");
                return;
            }

            m_Attaching = attaching;
        }

        public Transform GetTarget()
        {
            return m_MainCharacter.transform;
        }

        public void Init()
        {
            m_MainCharacter.Init();
            m_CharacterWeapon.Init();
        }

        public void StartShoot()
        {
            m_CharacterWeapon.Start();
        }

        public void StopShoot()
        {
            m_CharacterWeapon.Stop();
        }

        public void Move(Vector2 vector2)
        {
            m_MainCharacter.Move(vector2);
        }

        public WeaponType GetType()
        {
            return WeaponType.SimpleWeaponProjectile;
        }

        public Transform Where()
        {
            return m_MainCharacter.WeaponPoint;
        }

        public void Set(WeaponBehaviour generic)
        {
            if (m_CharacterWeapon == null)
            {
                m_CharacterWeapon = new CharacterWeapon();
                m_CharacterWeapon.Set(m_Attaching);
            }

            m_CharacterWeapon.AddWeapon(generic);
        }
    }
}