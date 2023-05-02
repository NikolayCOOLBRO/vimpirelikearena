using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemeisController : MonoBehaviour
    {
        [SerializeField] private List<EnemyCharacter> m_Enemies;

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

            foreach (var enemy in m_Enemies)
            {
                enemy.Move(m_Attaching.GetTarget().position);
            }
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