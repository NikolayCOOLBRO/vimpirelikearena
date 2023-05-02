using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemyMovement : IMoving
    {
        private Tween m_Tween;

        public void Move(Vector3 direction, float speed, Transform transform)
        {
            m_Tween?.Kill();

            m_Tween = DOTween.To(() => transform.position,
                                        setter => transform.position = setter,
                                        direction,
                                        speed);

            m_Tween.Play();
        }

        public void Stop()
        {
            m_Tween?.Kill();
        }
    }
}