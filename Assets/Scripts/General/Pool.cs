using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike
{
    public class PoolBehaviour<T> where T : MonoBehaviour
    {
        private List<T> m_Objects;

        public PoolBehaviour(T obj, int count)
        {
            m_Objects = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var clone = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);
                clone.gameObject.SetActive(false);
                m_Objects.Add(clone);
            }
        }

        public T Take()
        {
            foreach (var item in m_Objects)
            {
                if (item.gameObject.activeInHierarchy)
                {
                    continue;
                }

                item.gameObject.SetActive(true);
                return item;
            }
            return m_Objects[0];
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}