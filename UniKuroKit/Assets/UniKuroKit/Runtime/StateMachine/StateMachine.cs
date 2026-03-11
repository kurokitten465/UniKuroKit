using System;
using System.Runtime.CompilerServices;

namespace KuroKitten.UniKuroKit.StateMachine
{
    public sealed class StateMachine<TContext> : IStateMachine where TContext : struct
    {
        public bool Enabled { get; private set; } = true;

        IState<TContext> _currentState;
        IState<TContext> _nextState;

        readonly TContext _context;

        bool _enterFrame;

        public StateMachine(in TContext context)
        {
            _context = context;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Disable() => Enabled = false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Enable() => Enabled = true;

        public void ChangeState<TState>(TState state) where TState : new()
        {
            if (state is not IState<TContext> newState)
                throw new ArgumentException($"State: {typeof(IState<TContext>)}; Is not implement {typeof(IState<TContext>)}.");

            _nextState = newState;
        }

        public void ProcessTransition()
        {
            if (_nextState == null)
                return;

            _currentState?.OnExit(_context);

            _currentState = _nextState;
            _nextState = null;

            _currentState?.OnEnter(_context);

            _enterFrame = true;
        }

        public void FixedUpdate()
        {
            if (!Enabled)
                return;

            if (_enterFrame)
                return;

            _currentState?.OnFixedUpdate(_context);
        }

        public void Update()
        {
            if (!Enabled)
                return;

            if (_enterFrame)
            {
                _enterFrame = false;
                return;
            }

            _currentState?.OnUpdate(_context);
        }
    }
}
