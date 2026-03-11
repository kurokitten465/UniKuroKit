using UnityEngine;

namespace KuroKitten.UniKuroKit.StateMachine
{
    [CreateAssetMenu(fileName = "NewStateMachineSubsystemSO", menuName = "UniKuroKit/StateMachineSubsystemSO")]
    public class StateMachineSubsystemWrapper : ScriptableObject
    {
        readonly StateMachineSubsystem _stateMachineSubsystem = new();

        public void Register(IStateMachine stateMachine) =>
            _stateMachineSubsystem.Register(stateMachine);
        public void Unregister(IStateMachine stateMachine) =>
            _stateMachineSubsystem.Unregister(stateMachine);

        public void Active() => _stateMachineSubsystem.Enable();
        public void Disable() => _stateMachineSubsystem.Disable();
    }
}
