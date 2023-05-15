using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Players
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        public Player Player;

        public void Init()
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            Player = new Player();
            Player.Seed = Random.Range(0, 100000); 
        }
    }
}