using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemyMovement : IMoving
    {
        private bool m_IsStop;

        public void Move(Vector3 direction, float speed, Transform transform)
        {
            if (m_IsStop)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, direction, speed);
            
        }

        public void Stop()
        {
            m_IsStop = true;
        }
    }
}