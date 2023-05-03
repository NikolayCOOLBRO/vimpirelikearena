using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform m_StartPoint;

        [SerializeField] private Projectile m_ProjectilePref;
        [SerializeField] private float m_AttackSpeed;
        [SerializeField] private float m_ProjectileSpeed;
        [SerializeField] private float m_Distance;
        [SerializeField] private int m_Damage;

        [SerializeField] private bool m_IsStop;

        private PoolBehaviour<Projectile> m_Pool;
        private IAttaching m_Attaching;

        public void Awake()
        {
            m_Pool = new PoolBehaviour<Projectile>(m_ProjectilePref, 10);
        }

        public IEnumerator Shoot()
        {
            while (true)
            {
                if (m_IsStop)
                {
                    break;
                }

                var projectile = m_Pool.Take();
                projectile.transform.position = m_StartPoint.position;
                projectile.Damage = m_Damage;
                projectile.Move(m_ProjectileSpeed, m_Attaching.GetTarget().position, m_Distance);
            
                yield return new WaitForSeconds(m_AttackSpeed);
            }

            yield break;
        }

        public void Stop()
        {
            m_IsStop = false;
        }

        public void SetTarget(IAttaching attaching)
        {
            m_Attaching = attaching;
        }
    }
}