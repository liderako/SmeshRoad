using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Pool
{
    public class FloorPool : ObjectPool<Floor>
    {
        [SerializeField] private Floor _floor;
        private void Awake()
        {
            m_prefab = _floor;
            m_size = Resources.Load<Settings>("Settings/Settings").SizeFloorPool;
            base.Awake();
        }
    }
}
