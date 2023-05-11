using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Characters;
using VampireLike.Core.Characters.Enemies;

namespace VampireLike.Core.Levels
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private Transform m_Center;
        [SerializeField] private List<EnemyCharacter> m_Enemies;

        public Transform Center => m_Center;
        public List<EnemyCharacter> Enemies => m_Enemies;
    }
}