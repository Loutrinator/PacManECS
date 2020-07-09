using Accessor;
using UnityEngine;
using UnityEngine.AI;

namespace Modules {
    public enum FollowTargetState{Idle,Patrolling,Chasing,RunAway}
    public class FollowTarget : Module
    {
        public Entity target;
        public NavMeshAgent navAgent;
        public FollowTargetState state = FollowTargetState.Chasing;
        
        public override void Register()
        {
            TAccessor<FollowTarget>.Instance.Add(this);
        }

        public override void Awake()
        {
            base.Awake();
            if (navAgent == null)
            {
                navAgent = GetComponent<NavMeshAgent>();
            }
        }
    }
}
