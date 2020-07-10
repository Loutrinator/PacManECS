using Accessor;
using UnityEngine.AI;

namespace Modules {
    public class PlayerFollowTarget : ITarget
    {
        public Entity target;
        public NavMeshAgent navAgent;
        
        public override void Register()
        {
            TAccessor<PlayerFollowTarget>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<PlayerFollowTarget>.Instance.Remove(this);
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
