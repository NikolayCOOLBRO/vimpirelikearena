using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{

    public class WeaponSystem
    {
        private List<IWeapon> m_Weapons;

        public WeaponSystem()
        {
            m_Weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                Debug.LogError($"Class: {nameof(WeaponSystem)}:" +
                    $"\nMethode: - {nameof(AddWeapon)}. Null References");
                return;
            }

            m_Weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                Debug.LogError($"Class: {nameof(WeaponSystem)}:" +
                    $"\nMethode: - {nameof(RemoveWeapon)}. Null References");
                return;
            }

            m_Weapons.Remove(weapon);
        }
    }
}