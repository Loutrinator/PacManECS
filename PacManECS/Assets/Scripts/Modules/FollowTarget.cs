using Accessor;
using UnityEngine;
using UnityEngine.AI;

namespace Modules {
    public class FollowTarget : Module
    {
        public Entity target;
        public NavMeshAgent navAgent;
        public bool isChasing = false;
        public bool chasingTarget = false;
        public Vector3 chasingPosition;
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
