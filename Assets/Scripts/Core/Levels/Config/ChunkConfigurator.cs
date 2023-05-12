using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VampireLike.Core.Levels
{
    public class ChunkConfigurator : MonoBehaviour
    {
        [SerializeField] private ChunkConfig m_ChunkConfig;

        private Dictionary<int, List<Chunk>> m_Chunks;

        public void Init()
        {
            m_Chunks = new Dictionary<int, List<Chunk>>();

            foreach (var item in m_ChunkConfig.Chunks)
            {
                if (m_Chunks.ContainsKey(item.Tier))
                {
                    m_Chunks[item.Tier].Add(item);
                }
                else
                {
                    m_Chunks.Add(item.Tier, new List<Chunk>());
                    m_Chunks[item.Tier].Add(item);
                }
            }
        }

        public Chunk GetRandomChunk(int tier, int seed)
        {
            var random = new System.Random(seed);

            int index = random.Next(0, m_Chunks[tier].Count);

            return m_Chunks[tier][index];
        }
    }
}