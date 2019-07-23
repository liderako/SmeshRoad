using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace AliveObject.State
{
    public class DeathState : MonoBehaviour, IState
    {
        #region Inspector member
        
        [SerializeField] private ParticleSystem destroy;
        [SerializeField] private float timeParticleDuration; 
        #endregion

        #region Public Properties

        public delegate void MethodContainer(GameObject go);
        public event MethodContainer AliveObjectDead;

        #endregion

        #region Private Properties

        private Renderer _render;
        private Collider _collider;
        private bool     _isDead;

        #endregion

        #region Unity Methods

        public void Start()
        {
            _render = GetComponent<Renderer>();
            _collider = GetComponent<Collider>();
        }

        #endregion

        public void UpdateState()
        {
            if (!_isDead)
            {
                Die();
            }
        }
        
        protected virtual void Die()
        {
            destroy.Play();
            _isDead = true;
            _render.enabled = false;
            _collider.enabled = false;
            StartCoroutine(ReturnObjectOnPool(timeParticleDuration));
        }

        private IEnumerator ReturnObjectOnPool(float time)
        {
            yield return new WaitForSeconds(time);
            _render.enabled = true;
            _collider.enabled = true;
            _isDead = false;
            if (AliveObjectDead != null)
            {
                AliveObjectDead(gameObject);
            }
        }
    }
}