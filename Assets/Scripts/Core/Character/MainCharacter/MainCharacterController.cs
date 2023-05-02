using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Characters
{
    public class MainCharacterController : MonoBehaviour, IAttaching
    {
        [SerializeField] private MainCharacter m_MainCharacter;

        public Transform GetTarget()
        {
            return m_MainCharacter.transform;
        }

        public void Move(Vector2 vector2)
        {
            m_MainCharacter.Move(vector2);
        }
    }
}