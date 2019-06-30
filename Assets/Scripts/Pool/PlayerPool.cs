using System.Collections;
using System.Collections.Generic;
using AliveObject.Player;
using UnityEngine;

namespace Pool
{
    public class PlayerPool : ObjectPool<Player>
    {
        [SerializeField] private Player _player;
        private void Awake()
        {
            m_prefab = _player;
            m_size = Resources.Load<Settings>("Settings/Settings").SizePlayerPool;
            base.Awake();
        }
    }
}