namespace KuroKitten.UniKuroKit.StateMachine
{
    public interface IStateMachine
    {
        bool Enabled { get; }
        void Enable();
        void Disable();
        void ChangeState<TState>(TState state) where TState : new();
        void ProcessTransition();
        void FixedUpdate();
        void Update();
    }
}
