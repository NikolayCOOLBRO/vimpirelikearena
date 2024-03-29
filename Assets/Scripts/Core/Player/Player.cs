using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Players
{
    [System.Serializable]
    public class Player
    {
        [SerializeField] private int m_Seed;
        [SerializeField] private int m_QtyCompleteArens;
        [SerializeField] private int m_Node;
        [SerializeField] private int m_QtyArenas;

        public int Seed 
        {
            get => m_Seed;
            set => m_Seed = value;
        }

        public int QtyCompleteArean
        {
            get => m_QtyCompleteArens;
            set => m_QtyCompleteArens = value;
        }

        public int Node
        {
            get => m_Node;
            set => m_Node = value;
        }

        public int QtyArenas
        {
            get => m_QtyArenas;
            set => m_QtyArenas = value;
        }
    }
}