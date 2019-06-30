using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.State;

namespace AliveObject.Enemy.State
{
    public class EnemyDeathState : DeathState
    {

        public void UpdateState()
        {
            Die();
        }
        protected override void Die()
        {
            // Увеличить скор
			base.Die();
        }
    }
}