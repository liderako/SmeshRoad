using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trap;

namespace Pool
{
    public class TrapPool : ObjectPool<BaseTrap>
    {
        [SerializeField] private List<BaseTrap> _prebabs;
        private void Awake()
        {
            m_size = Resources.Load<Settings>("Settings/Settings").SizeTrapPool;
            BaseAwake();
        }
        
        private void BaseAwake()
        {
            m_freeList = new List<BaseTrap>(m_size);
            m_usedList = new List<BaseTrap>(m_size);

            // Instantiate the pooled objects and disable them.
            for (var i = 0; i < m_size; i++)
            {
                var pooledObject = Instantiate(_prebabs[i % _prebabs.Count], transform);
                pooledObject.gameObject.SetActive(false);
                m_freeList.Add(pooledObject);
            }
        }
    }
}
