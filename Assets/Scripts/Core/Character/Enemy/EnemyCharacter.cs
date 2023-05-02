using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters.Enemies
{
    public class EnemyCharacter : MonoBehaviour
    {
        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;

        private void Awake()
        {
            m_CharacterData = new CharacterData()
            {
                Speed = 3f
            };
            m_CharacterMovement = new EnemyMovement();
        }

        public void Move(Vector3 targetPosition)
        {
            m_CharacterMovement.Move(targetPosition, m_CharacterData.Speed, transform);
        }
    }
}