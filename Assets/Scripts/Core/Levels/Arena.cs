using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Levels
{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private Transform m_StartPoint;
        [SerializeField] private Transform m_EndPoint;
        [SerializeField] private Transform m_CenterArena;

        public Transform StartPoint => m_StartPoint;
        public Transform EndPoint => m_EndPoint;
        public Transform CenterArena => m_CenterArena;

        private Tween m_Tween;

        public void Scale(Vector3 scale, Action action = null)
        {
            m_Tween?.Kill();

            m_Tween = DOTween.To(() => transform.localScale,
                                setter => transform.localScale = setter,
                                scale,
                                1f)
                        .SetEase(Ease.InOutBack)
                        .OnComplete(() =>
                        {
                            action?.Invoke();
                        });

            m_Tween.Play();
        }
    }
}