using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Input;

namespace VampireLike.Core.Characters
{
    public class MainCharacter : MonoBehaviour
    {
        
        private CharacterData m_CharacterData;
        private IMoving m_CharacterMovement;

        private void Awake()
        {
            m_CharacterData = new CharacterData()
            {
                Speed = 7f,
                HealthPoints = 100
            };
            m_CharacterMovement = new CharacterMovement();
        }

        public void Move(Vector2 deriction)
        {
            m_CharacterMovement.Move(new Vector3(deriction.x, 0f, deriction.y), m_CharacterData.Speed, transform);
        }
    }
}