using UnityEngine;

namespace VampireLike.Core.Levels
{
    [System.Serializable]
    public struct ChunkTier
    {
        [SerializeField] private int m_Tier;
        [SerializeField] private int m_СhanceStart;
        [SerializeField] private int m_ChanceMid;
        [SerializeField] private int m_ChanceEnd;

        public int Tier => m_Tier;
        public int ChanceStart => m_СhanceStart;
        public int ChanceMid => m_ChanceMid;
        public int ChanceEnd => m_ChanceEnd;
    }
}