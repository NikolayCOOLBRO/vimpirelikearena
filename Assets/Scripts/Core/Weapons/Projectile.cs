using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{

    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> OnHit;

        public int Damage { get; set; }

        public float RepulsiveForce { get; set; }

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

        private void Update()
        {
            if (!m_IsMove)
            {
                return;
            }

            var step = m_Speed * Time.deltaTime;
            var oldPostion = transform.position;

            transform.position = Vector3.MoveTowards(transform.position, m_Target, step);

            var direction = (m_Target - transform.position).normalized;

            var lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, step);

            if (Vector3.Distance(m_StartPosition, transform.position) >= m_Distance)
            {
                m_IsMove = false;
                gameObject.SetActive(false);
            }

            if (Vector3.Distance(oldPostion, transform.position) <= float.Epsilon)
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

            if (collision.gameObject.TryGetComponent<IRepelled>(out var repelled))
            {
                 repelled.Push(transform.forward, RepulsiveForce);
            }

            Hit();
        }

        private void Hit()
        {
            gameObject.SetActive(false);


            OnHit?.Invoke(this);
        }
    }
}