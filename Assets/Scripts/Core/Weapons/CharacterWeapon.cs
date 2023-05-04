using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{

    public class CharacterWeapon
    {
        private List<WeaponBehaviour> m_Weapons;

        public CharacterWeapon()
        {
            m_Weapons = new List<WeaponBehaviour>();
        }

        public void Start()
        {
            foreach (var item in m_Weapons)
            {
                item.Shoot();
            }
        }

        public void Stop()
        {
            foreach (var item in m_Weapons)
            {
                item.Stop();
            }
        }

        public void AddWeapon(WeaponBehaviour weapon)
        {
            if (weapon == null)
            {
                Debug.LogError($"Class: {nameof(CharacterWeapon)}:" +
                    $"\nMethode: - {nameof(AddWeapon)}. Null References");
                return;
            }

            m_Weapons.Add(weapon);
        }

        public void RemoveWeapon(WeaponBehaviour weapon)
        {
            if (weapon == null)
            {
                Debug.LogError($"Class: {nameof(CharacterWeapon)}:" +
                    $"\nMethode: - {nameof(RemoveWeapon)}. Null References");
                return;
            }

            m_Weapons.Remove(weapon);
        }
    }
}