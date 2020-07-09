using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class FollowTargetUpdater : IUpdater
    {
    
        public override void DoUpdate()
        {
            for (int i = 0; i < TAccessor<FollowTarget>.Instance.Modules.Count; ++i)
            {
                Debug.Log("Follow Target number " + i);
                FollowTarget follower = TAccessor<FollowTarget>.Instance.Modules[i];
                if (follower.target != null)
                {
                    follower.navAgent.SetDestination(follower.target.transform.position);
                    follower.navAgent.isStopped = false;
                }
                else
                {
                    follower.navAgent.isStopped = true;
                }
            }
        }
    }
}
