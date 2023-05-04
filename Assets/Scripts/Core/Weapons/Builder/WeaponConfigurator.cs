using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{
    public class WeaponConfigurator : MonoBehaviour
    {
        [SerializeField] private WeaponConfig m_WeaponConfig;

        public WeaponDTO GetData(WeaponType weaponType)
        {
            var data = m_WeaponConfig.WeaponData.Find(item => item.WeaponType.Equals(weaponType));
            var prefab = m_WeaponConfig.ListModelWeapons.Find(item => item.WeaponType.Equals(weaponType));

            var dto = new WeaponDTO();

            if (!data.ProjectileType.Equals(ProjectileType.None))
            {
                var projectile = m_WeaponConfig.ListModelProjectile.Find(item => item.ProjectileType.Equals(data.ProjectileType));

                dto.WeaponData = new ProjectileWeaponData()
                {
                    Damage = data.Damage,
                    AttackSpeed = data.AttackSpeed,
                    ProjectileSpeed = data.ProjectileSpeed,
                    Distance = data.Distance,
                    ProjectilePref = projectile.Projectile
                };
            }
            else
            {
                dto.WeaponData = new WeaponData()
                {
                    Damage = data.Damage,
                    AttackSpeed = data.AttackSpeed
                };
            }


            dto.WeaponBehaviour = prefab.WeaponBehaviour;
            return dto;
        }
    }
}