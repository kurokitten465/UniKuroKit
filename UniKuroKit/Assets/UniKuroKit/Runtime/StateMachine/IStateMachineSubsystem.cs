namespace KuroKitten.UniKuroKit.StateMachine
{
    public interface IStateMachineSubsystem
    {
        bool Enabled { get; }
        void Enable();
        void Disable();
        void Register(IStateMachine machine);
        void Unregister(IStateMachine machine);
        void ProcessTransition();
        void Update();
        void FixedUpdate();
    }
}
