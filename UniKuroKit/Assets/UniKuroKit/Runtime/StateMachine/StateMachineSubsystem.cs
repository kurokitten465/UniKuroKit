using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KuroKitten.UniKuroKit.StateMachine
{
    public sealed class StateMachineSubsystem: IStateMachineSubsystem
    {
        private readonly List<IStateMachine> _machines = new();

        public bool Enabled { get; private set; } = true;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Disable() => Enabled = false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Enable() => Enabled = true;

        public void Register(IStateMachine machine)
        {
            if (!_machines.Contains(machine))
                _machines.Add(machine);
        }

        public void Unregister(IStateMachine machine)
        {
            _machines.Remove(machine);
        }

        public void Update()
        {
            if (!Enabled)
                return;

            for (int i = 0; i < _machines.Count; i++)
            {
                var m = _machines[i];

                if (m.Enabled)
                    m.Update();
            }
        }

        public void FixedUpdate()
        {
            if (!Enabled)
                return;

            for (int i = 0; i < _machines.Count; i++)
            {
                var m = _machines[i];

                if (m.Enabled)
                    m.FixedUpdate();
            }
        }

        public void ProcessTransition()
        {
            for (int i = 0; i < _machines.Count; i++)
            {
                _machines[i].ProcessTransition();
            }
        }
    }
}
