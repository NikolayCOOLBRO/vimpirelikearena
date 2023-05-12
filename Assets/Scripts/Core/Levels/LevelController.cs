using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Level m_Level;
        
        public void NextArena()
        {
            m_Level.NextArena();
        }

        public void SetChunk(Chunk chunk)
        {
            m_Level.SetChunk(chunk);
        }
    }
}