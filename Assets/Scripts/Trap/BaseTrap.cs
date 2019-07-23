using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;
using Managers;
using Trap.State;

namespace Trap
{
    public class BaseTrap : MonoBehaviour
    {
        #region Properites
        
        #region Private properties

        private Animator _animator;
        private bool _canActivate;
        private Renderer _renderer;

        #endregion

        #region Protected properties

        protected IState    _state;

        #endregion

        #region Inspector Properties
        [SerializeField] private WaitState _waitState;
        [SerializeField] private DeactivateState _deactivateState;
        [SerializeField] private ActivateState _activateState;
        [SerializeField] private List<Renderer> _grounds;
        #endregion
        
        #endregion
        
        #region Unity Methods

        void Start()
        {
            _animator = GetComponent<Animator>();
            for (int i = 0; i < _grounds.Count; i++)
            {
                _grounds[i].material.color = ColorManager.CM.WaitColorTrap;
            }
            _activateState.BaseInit(this, _animator);
            _deactivateState.BaseInit(ref _canActivate, this, _animator);
            _state = _waitState;
            ChangeState(_state);
            LevelManager.LM.Clear += Clear;
        }

        void Update()
        {
            _state.UpdateState();
        }

        #endregion
        public void ChangeState(IState state)
        {
            _state = state;
        }
        public void TriggerOn()
        {
            _canActivate = true;
            for (int i = 0; i < _grounds.Count; i++)
            {
                _grounds[i].material.color = ColorManager.CM.AvailableColorTrap;
            }
            _waitState.BaseInit(_canActivate, this);
        }

        public void TriggerOff()
        {
            _canActivate = true;
            for (int i = 0; i < _grounds.Count; i++)
            {
                _grounds[i].material.color = ColorManager.CM.UnavailableColorTrap;
            }
            _waitState.BaseInit(false, this);
        }

        private void Clear()
        {
            _canActivate = false;
            for (int i = 0; i < _grounds.Count; i++)
            {
                _grounds[i].material.color = ColorManager.CM.WaitColorTrap;
            }
            _waitState.BaseInit(false, this);
            LevelManager.LM.ReturnTrap(gameObject);
        }
    }
}