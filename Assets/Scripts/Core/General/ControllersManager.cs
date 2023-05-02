using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Characters;
using VampireLike.Core.Characters.Enemies;
using VampireLike.Core.Input;

namespace VampireLike.Core.General
{

    public class ControllersManager : MonoBehaviour
    {
        [SerializeField] private EnemeisController m_EnemeisController;
        [SerializeField] private PlayerInput m_PlayerInput;
        [SerializeField] private MainCharacterController m_MainCharacterController;

        public void ControllersInit()
        {
            m_EnemeisController.SetAttaching(m_MainCharacterController);
            m_MainCharacterController.SetAttaching(m_EnemeisController);

            m_PlayerInput.OnInput += OnDragJoystickPlayer;

            m_EnemeisController.Init();
            m_MainCharacterController.Init();
        }

        private void OnDragJoystickPlayer(Vector2 vector2)
        {
            m_MainCharacterController.Move(vector2);
            m_EnemeisController.Attach();
        }

        private void OnDestroy()
        {
            m_PlayerInput.OnInput += OnDragJoystickPlayer;
        }
    }
}