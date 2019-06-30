using System.Collections;
using System.Collections.Generic;
using AliveObject.Enemy;
using UnityEngine;

namespace Pool
{
    public class EnemyPool : ObjectPool<Enemy>
    {
        [SerializeField] private Enemy _enemy;
        private void Awake()
        {
            m_prefab = _enemy;
            m_size = Resources.Load<Settings>("Settings/Settings").SizeEnemyPool;
            base.Awake();
        }

    }
}