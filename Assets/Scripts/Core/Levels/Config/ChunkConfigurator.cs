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
        /*
        public Chunk GetNumberArenaChunk(int numberArena, int seed)
        {
            var random = new System.Random(seed);

            int zero = 0;

            var dic = new Dictionary<int, int>();

            List<(int, ChunkTier)> list = new List<(int, ChunkTier)>();

            if (numberArena == 1)
            {
                foreach (var item in m_ChunkConfig.ChunkTiers)
                {
                    zero += item.ChanceStart;
                    list.Add((zero, item));
                }
            }
            else if (numberArena == 5)
            {
                foreach (var item in m_ChunkConfig.ChunkTiers)
                {
                    zero += item.ChanceEnd;
                    list.Add((zero, item));
                }
            }
            else
            {
                foreach (var item in m_ChunkConfig.ChunkTiers)
                {
                    zero += item.ChanceMid;
                    list.Add((zero, item));
                }
            }

            int randomValue = random.Next(0, 100);

            var chunkTier = new ChunkTier();

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    if (randomValue <= list[i].Item1)
                    {
                        chunkTier = list[i].Item2;
                    }
                }
                else if(i == list.Count - 1)
                {
                    chunkTier = list[i].Item2;
                }

            }



            return GetRandomChunk(chunkTier.Tier, seed);
        }
        */
        public Chunk GetRandomChunk(int tier, int seed)
        {
            var random = new System.Random(seed);

            int index = random.Next(0, m_Chunks[tier].Count);

            return m_Chunks[tier][index];
        }
    }
}