using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Levels
{
    [CreateAssetMenu(fileName = "Chunk Config", menuName = "Configs/Levels/Chunk Config")]
    public class ChunkConfig : ScriptableObject
    {
        [SerializeField] private List<Chunk> m_Chunks;

        public List<Chunk> Chunks => m_Chunks;
    }
}