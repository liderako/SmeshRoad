//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Enemy


//    public class BaseEnemyState : MonoBehaviour
//    {
//        protected Enemy _owner;

//        protected void BaseInit(Enemy owner)
//        {
//            _owner = owner;
//        }
//    }

//    public class RunState : BaseEnemyState, IState
//    {
//        public void BaseInit(Enemy owner)
//        {
//            base.BaseInit(owner);
//        }

//        public void UpdateState()
//        {
//            // move
//        }

//        public void OnCollisionEnter(Collision collision)
//        {
//            if (collision.gameObject.layer == 9)
//            {
//                _owner.ChangeState(new DeadState(_owner));
//            }
//            else if (collision.gameObject.layer == 8)
//            {
//                _owner.ChangeState(gameObject.AddComponent<AttackState>());
//                _owner.Dele
//            }
//        }
//    }


//    public class DeadState : BaseEnemyState, IState
//    {
//        public void BaseInit(Enemy owner)
//        {
//            base.BaseInit(owner);
//        }

//        public void UpdateState()
//        {
//            //Destroy(_owner.gameObject);
//        }

//        private void Dead()
//        {
//            Destroy(gameObject); // objective pool need
//        }
//    }

//    public class AttackState : BaseEnemyState, IState
//    {
//        public void BaseInit(Enemy owner)
//        {
//            base.BaseInit(owner);
//        }

//        public void UpdateState()
//        {
//            //Destroy(_owner.gameObject);
//            // _owner.ChangeState(new DeadState(_owner));
//        }
//    }

//    public class Enemy : MonoBehaviour
//    {
//        private IState _state;

//        public void Start()
//        {
//            _state = gameObject.GetComponent<IState>();
//        }

//        public void Update()
//        {
//            _state.UpdateState();
//        }

//        public void ChangeState(IState state)
//        {
//            _state = state;
//        }
//    }
//}