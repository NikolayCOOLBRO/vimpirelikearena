using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VampireLike.Core.Input;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemeisController : MonoBehaviour, IIniting, IAttaching
    {
        [SerializeField] private List<EnemyCharacter> m_Enemies;
        [SerializeField] private bool m_IsMove;

        private IAttaching m_Attaching;

        public IEnumerable<INeedingWeapon> NeedingWeapons => m_Enemies.OfType<INeedingWeapon>();

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

        public void StartShoot()
        {
            foreach (var item in m_Enemies)
            {
                item.StartShoot();
            }
        }

        public void StopShoot()
        {
            foreach (var item in m_Enemies)
            {
                item.StopShoot();
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
                enemy.SetCharacterData(new CharacterData() { 
                    Speed = 7,
                    ScaleDamage = 1,
                    HealthPoints = 5
                });
                enemy.SetCharacterMovement(new EnemyMovement());
                enemy.Set(m_Attaching);
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
            foreach (var item in m_Enemies)
            {
                item.Set(m_Attaching);
            }
        }
    }
}