using UnityEngine;
using KuroKitten.UniKuroKit.StateMachine;

namespace KuroKitten.UniKuroKit.Samples
{
    public class PlayerIdleState : IState<PlayerContext>
    {
        public void OnEnter(in PlayerContext ctx)
        {
            Debug.Log($"Entering: {this}");
        }

        public void OnExit(in PlayerContext ctx)
        {
            Debug.Log($"Exiting: {this}");
        }

        public void OnFixedUpdate(in PlayerContext ctx)
        {
            
        }

        public void OnUpdate(in PlayerContext ctx)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                ctx.Owner.ChangeState(new PlayerWalkState());
            }
        }
    }
}
