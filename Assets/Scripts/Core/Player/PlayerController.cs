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
            Player.Node = 0;
            Player.QtyCompleteArean = 0;
            Player.QtyArenas = 5;
        }

        public void StartRoad()
        {
            Player.Node++;
        }

        public void CompleteArena()
        {
            Player.QtyCompleteArean++;
        }

        public void CompleteLevel()
        {
            Player.QtyCompleteArean = 0;
            Player.Node = 0;
        }

        public bool IsCompleteLevel()
        {
            return Player.QtyCompleteArean > Player.QtyArenas;
        }
    }
}