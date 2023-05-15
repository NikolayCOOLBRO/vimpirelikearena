using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Players
{
    [System.Serializable]
    public class Player
    {
        [SerializeField] private int m_Seed;
        [SerializeField] private int m_QtyCompleteArean;

        public int Seed 
        {
            get => m_Seed;
            set => m_Seed = value;
        }

        public int QtyCompleteArean
        {
            get => m_QtyCompleteArean;
            set => m_QtyCompleteArean = value;
        }
    }
}