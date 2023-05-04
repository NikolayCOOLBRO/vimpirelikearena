using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.Characters
{
    public class MainCharacterController : MonoBehaviour, IAttaching, IIniting
    {
        [SerializeField] private MainCharacter m_MainCharacter;
        [SerializeField] private WeaponBehaviour m_Weapon;

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

            m_Weapon.Shoot();
        }

        public void Move(Vector2 vector2)
        {
            m_MainCharacter.Move(vector2);
        }

    }
}