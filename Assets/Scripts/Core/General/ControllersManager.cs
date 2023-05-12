using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Characters;
using VampireLike.Core.Characters.Enemies;
using VampireLike.Core.Input;
using VampireLike.Core.Levels;
using VampireLike.Core.Weapons;

namespace VampireLike.Core.General
{

    public class ControllersManager : MonoBehaviour
    {
        [SerializeField] private EnemeisController m_EnemeisController;
        [SerializeField] private PlayerInput m_PlayerInput;
        [SerializeField] private MainCharacterController m_MainCharacterController;
        [SerializeField] private WeaponsController m_WeaponsController;
        [SerializeField] private LevelController m_LevelController;

        public void ControllersInit()
        {
            m_EnemeisController.SetAttaching(m_MainCharacterController);
            m_MainCharacterController.SetAttaching(m_EnemeisController);
            m_WeaponsController.GaveWeapon(m_MainCharacterController);

            m_PlayerInput.OnInput += OnDragJoystickPlayer;
            m_EnemeisController.OnAllDeadEnemies += OnAllDeadEnemies;
            m_LevelController.OnSetChunk += OnSetChunk;

            m_EnemeisController.Init();
            m_MainCharacterController.Init();
            m_LevelController.Init();

            m_LevelController.FirstArena();
            StartGameLoop();
        }

        private void OnDragJoystickPlayer(Vector2 vector2)
        {
            m_MainCharacterController.Move(vector2);
        }

        private void OnDestroy()
        {
            m_PlayerInput.OnInput -= OnDragJoystickPlayer;
            m_EnemeisController.OnAllDeadEnemies -= m_MainCharacterController.StopShoot;
            m_LevelController.OnSetChunk -= OnSetChunk;
        }

        private void StartGameLoop()
        {
            m_MainCharacterController.StartShoot();
            m_EnemeisController.StartShoot();
        }

        private void OnAllDeadEnemies()
        {
            m_MainCharacterController.StopShoot();
            
            m_LevelController.NextArena();
        }

        private void OnSetChunk(Chunk chunk)
        {
            m_EnemeisController.SetEnemies(chunk.Enemies);
            m_EnemeisController.InitEnemy();
            m_WeaponsController.GaveWeapons(m_EnemeisController.NeedingWeapons);
        }
    }
}