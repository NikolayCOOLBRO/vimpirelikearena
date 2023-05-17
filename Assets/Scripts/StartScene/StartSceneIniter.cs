using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireLike.Core.Players;



namespace VampireLike.StartScenes
{
    public class StartSceneIniter : MonoBehaviour
    {
        [SerializeField] private PlayerController m_PlayerController;

        private void Awake()
        {
            m_PlayerController.Init();

            var scene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            
        }
    }
}