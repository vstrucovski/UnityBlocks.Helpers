using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBlocks.Helpers.FSM
{
    public class BaseBrainFSM
    {
        private BaseStateFSM _currentState;
        private readonly Dictionary<Type, BaseStateFSM> _states = new();
        private bool _isDebug;

        public BaseStateFSM CurrentState => _currentState;

        public event Action<BaseStateFSM> OnEnter;

        public void AddState<TState>(TState state) where TState : BaseStateFSM
        {
            _states[typeof(TState)] = state;
            state.SetStateMachine(this);

            if (_isDebug)
            {
                Debug.Log("FSM. + Added state: " + state);
            }

            state.Init();
        }

        public virtual void Enter<TState>() where TState : BaseStateFSM
        {
            if (_currentState is TState)
            {
                if (_isDebug)
                {
                    Debug.Log("FSM. State already active: " + typeof(TState));
                }

                return;
            }

            if (_states.TryGetValue(typeof(TState), out var newState))
            {
                _currentState?.OnExit();
                _currentState = newState;
                _currentState.OnEnter();
                OnEnter?.Invoke(_currentState);

                if (_isDebug)
                {
                    Debug.Log("FSM. >> Enter: " + typeof(TState));
                }
            }
            else
            {
                Debug.Log("State is not registered: " + typeof(TState));
            }
        }

        public virtual void Enter<TState, TCustomPayload>(TCustomPayload customPayload)
            where TState : BaseStateFsmWithPayload<TCustomPayload>
        {
            if (_currentState is TState)
            {
                if (_isDebug)
                {
                    Debug.Log("FSM. State already active: " + typeof(TState));
                }

                return;
            }

            if (_states.TryGetValue(typeof(TState), out var newState) &&
                newState is BaseStateFsmWithPayload<TCustomPayload> stateWithPayload)
            {
                _currentState?.OnExit();
                _currentState = stateWithPayload;
                stateWithPayload.OnEnter(customPayload);
                OnEnter?.Invoke(_currentState);

                if (_isDebug)
                {
                    Debug.Log("FSM. >> Enter with payload: " + typeof(TState));
                }
            }
            else
            {
                Debug.Log("State is not registered or incorrect payload type: " + typeof(TState));
            }
        }

        public void SetDebug(bool status)
        {
            _isDebug = status;
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}