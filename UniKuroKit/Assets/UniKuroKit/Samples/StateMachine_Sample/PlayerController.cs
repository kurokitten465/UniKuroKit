using UnityEngine;
using KuroKitten.UniKuroKit.StateMachine;

namespace KuroKitten.UniKuroKit.Samples
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _movementSpeed = 2f;
        public float MovementSpeed => _movementSpeed;
        [SerializeField] float _jumpForce = 3f;
        public float JumpForce => _jumpForce;

        [SerializeField] StateMachineSubsystemWrapper _stateMachineSubsystem;

        StateMachine<PlayerContext> _stateMachine;

        Rigidbody2D _rigidbody2D;
        PlayerContext _playerContext;

        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _playerContext = new(
                this,
                _rigidbody2D
            );

            _stateMachine = new(_playerContext, _stateMachineSubsystem.Subsystem);
        }

        void Start()
        {
            _stateMachine.ChangeState(new PlayerIdleState());
        }

        void OnEnable()
        {
            _stateMachine.Enable();
        }

        void OnDisable()
        {
            _stateMachine.Disable();
        }

        void OnDestroy()
        {
            _stateMachineSubsystem.Unregister(_stateMachine);
        }

        public void ChangeState<TState>(TState state) where TState : new()
        {
            _stateMachine.ChangeState(state);
        }
    }

    public readonly struct PlayerContext : IStateContext
    {
        public readonly PlayerController Owner;
        public readonly Rigidbody2D Rigidbody2D;

        public PlayerContext(PlayerController owner, Rigidbody2D rigidbody2D)
        {
            Owner = owner;
            Rigidbody2D = rigidbody2D;
        }
    }
}
