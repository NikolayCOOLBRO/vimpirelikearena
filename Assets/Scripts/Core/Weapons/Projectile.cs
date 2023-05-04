using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{

    public class Projectile : MonoBehaviour
    {
        public int Damage { get; set; }

        private bool m_IsMove;
        private float m_Speed;
        private float m_Distance;

        private Vector3 m_Target;
        private Vector3 m_StartPosition;

        public void Move(float speed, Vector3 point, float distance)
        {
            m_Speed = speed;
            m_IsMove = true;
            m_Target = point;
            m_Distance = distance;
            m_StartPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (!m_IsMove)
            {
                return;
            }

            var step = m_Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, m_Target, step);

            if (Vector3.Distance(m_StartPosition, transform.position) >= m_Distance)
            {
                m_IsMove = false;
                gameObject.SetActive(false);
            }
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            m_IsMove = false;

            gameObject.SetActive(false);
            if (collision.gameObject.TryGetComponent<ITakingDamage>(out var takingDamage))
            {
                takingDamage.TakeDamage(Damage);
            }

        }
    }
}