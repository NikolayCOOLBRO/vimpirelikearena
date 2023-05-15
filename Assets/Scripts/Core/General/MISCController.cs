using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireLike.Core.Cameras;

namespace VampireLike.Core
{
    public class MISCController : MonoBehaviour
    {
        [SerializeField] private FollowerCamera m_FollowerCamera;

        public void Init()
        {
            m_FollowerCamera.FixPostion();
        }
    }
}