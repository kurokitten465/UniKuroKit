using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace KuroKitten.UniKuroKit.StateMachine
{
    public static class StateMachinePlayerLoop
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Install()
        {
            var playerLoop = PlayerLoop.GetCurrentPlayerLoop();

            Inject(ref playerLoop, typeof(EarlyUpdate), StateMachineScheduler.ProcessTransition);
            Inject(ref playerLoop, typeof(Update), StateMachineScheduler.Update);
            Inject(ref playerLoop, typeof(FixedUpdate), StateMachineScheduler.FixedUpdate);

            PlayerLoop.SetPlayerLoop(playerLoop);
        }

        private static void Inject(ref PlayerLoopSystem root, Type target, PlayerLoopSystem.UpdateFunction fn)
        {
            for (int i = 0; i < root.subSystemList.Length; i++)
            {
                ref var sys = ref root.subSystemList[i];

                if (sys.type == target)
                {
                    var list = new List<PlayerLoopSystem>(sys.subSystemList)
                    {
                        new() {
                            type = typeof(StateMachineScheduler),
                            updateDelegate = fn
                        }
                    };

                    sys.subSystemList = list.ToArray();
                    return;
                }
            }
        }
    }
}
