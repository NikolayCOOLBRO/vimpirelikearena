using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{
    public class ProjectileWeapon : WeaponBehaviour, INeeding<IAttaching>
    {
        [SerializeField] private Transform m_StartPoint;
        [SerializeField] private bool m_IsStop;

        private IAttaching m_Attaching;
        private PoolBehaviour<Projectile> m_Pool;
        private ProjectileWeaponData m_ProjectileWeaponData;

        public override void Init()
        {
            m_Pool = new PoolBehaviour<Projectile>();
            m_Pool.CreateParent(transform);
            m_Pool.Pooling(m_ProjectileWeaponData.ProjectilePref, 15);
        }

        public void Set(IAttaching generic)
        {
            m_Attaching = generic;
        }

        public override void Shoot()
        {
            StartCoroutine(ShootCoroutine());
        }

        public override void Stop()
        {
            m_IsStop = false;
        }

        public override void SetWeaponData(WeaponData weaponData)
        {
            if (weaponData == null)
            {
                Debug.LogError($"Class: {nameof(ProjectileWeapon)}." +
                    $"\nMethode: - {nameof(SetWeaponData)}. Null References - {nameof(weaponData)}");
                return;
            }

            var projectileWeaponData = weaponData as ProjectileWeaponData;

            if (projectileWeaponData == null)
            {
                Debug.LogError($"Class: {nameof(ProjectileWeapon)}." +
                    $"\nMethode: - {nameof(SetWeaponData)}. Failed to convert - {nameof(projectileWeaponData)}");
                return;
            }

            m_ProjectileWeaponData = projectileWeaponData;

            base.SetWeaponData(weaponData);
        }

        private IEnumerator ShootCoroutine()
        {
            while (true)
            {
                if (m_IsStop)
                {
                    break;
                }

                var projectile = m_Pool.Take();
                projectile.transform.position = m_StartPoint.position;
                projectile.Damage = m_ProjectileWeaponData.Damage;
                projectile.Move(m_ProjectileWeaponData.ProjectileSpeed, m_Attaching.GetTarget().position, m_ProjectileWeaponData.Distance);

                yield return new WaitForSeconds(m_ProjectileWeaponData.AttackSpeed);
            }

            yield break;
        }
    }
}