using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace AliveObject.State
{
    public class DeathState : MonoBehaviour, IState
    {
        public void BaseInit()
        {
        }

        public void UpdateState()
        {
            Die();
        }

        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}