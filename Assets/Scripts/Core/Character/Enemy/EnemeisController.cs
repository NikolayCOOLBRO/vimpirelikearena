using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemeisController : MonoBehaviour, IIniting, IAttaching
    {
        [SerializeField] private List<EnemyCharacter> m_Enemies;
        [SerializeField] private bool m_IsMove;

        private IAttaching m_Attaching;

        public void Attach()
        {
            if (m_Attaching == null)
            {
                Debug.LogError($"Class - {nameof(EnemeisController)}:\n" +
                               $"Method - {nameof(Attach)}. Null References - {nameof(m_Attaching)}.");
                return;
            }

            if (m_Enemies == null)
            {
                Debug.LogError($"Class - {nameof(EnemeisController)}:\n" +
                               $"Method - {nameof(Attach)}. Null References - {nameof(m_Enemies)}.");
                return;
            }

            if (!m_IsMove)
            {
                return;
            }

            foreach (var enemy in m_Enemies)
            {
                enemy.Move(m_Attaching);
            }
        }

        public Transform GetTarget()
        {
            EnemyCharacter enemyCharacter = null;

            var position = m_Attaching.GetTarget().position;
            float distace = Vector3.Distance(position, m_Enemies[0].transform.position);

            foreach (var enemy in m_Enemies)
            {
                var ray = new Ray(position, enemy.transform.position);

                float calculateDistance = Vector3.Distance(position, enemy.transform.position);
                if (calculateDistance <= distace)
                {
                    distace = calculateDistance;
                    enemyCharacter = enemy;
                }
            }

            return enemyCharacter.transform;
        }

        public void Init()
        {
            foreach (var enemy in m_Enemies)
            {
                enemy.Init();
            }

            Attach();
        }

        public void SetAttaching(IAttaching attaching)
        {
            if (attaching == null)
            {
                Debug.LogError($"Class - {nameof(EnemeisController)}:\n" +
                               $"Method - {nameof(SetAttaching)}. Null References - {nameof(attaching)}.");
                return;
            }

            m_Attaching = attaching;
        }
    }
}