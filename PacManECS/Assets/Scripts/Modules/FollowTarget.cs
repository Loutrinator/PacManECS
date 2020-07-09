using Accessor;
using UnityEngine.AI;

namespace Modules {
    public class FollowTarget : Module
    {
        public Entity target;
        public NavMeshAgent navAgent;
        public override void Register()
        {
            TAccessor<FollowTarget>.Instance.Add(this);
        }

        public void Start()
        {
            if (navAgent == null)
            {
                navAgent = GetComponent<NavMeshAgent>();
            }
        }
    }
}
