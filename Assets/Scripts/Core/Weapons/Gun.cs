using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{
    public class Gun : MonoBehaviour//, IWeapon
    {
        [SerializeField] private Projectile m_Projectile;

        [SerializeField] private int m_Damage;
        [SerializeField] private float m_Speed;

        [SerializeField] private IAttaching m_Target;

        public void SetTarget(IAttaching target)
        {
            m_Target = target;
        }

        public void Shoot()
        {
            m_Projectile.Damage = m_Damage;
        }

        //¬Œ“ “”“ Œƒ»Õ »« ¬¿–»¿Õ“Œ¬ —“–≈À‹¡€

        /*
        private void Update()
        {
            float step = m_Speed * Time.deltaTime;
            m_Projectile.transform.position = Vector3.MoveTowards(m_Projectile.transform.position, m_Target.transform.position, step);
        }*/
    }
}