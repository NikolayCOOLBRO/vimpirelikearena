using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{

    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private WeaponConfigurator m_WeaponConfigurator;

        public void GaveWeapon(INeedingWeapon needingWeapon)
        {
            var data = m_WeaponConfigurator.GetData(needingWeapon.GetType());

            if (needingWeapon.GetType().Equals(WeaponType.SimpleWeaponProjectile))
            {
                var builder = new WeaponBuilder(needingWeapon.Where())
                                    .SetWeaponData(data.WeaponData)
                                    .SetWeaponBehaviour(data.WeaponBehaviour);

                needingWeapon.Set(builder.Build());
            }
        }


    }
}