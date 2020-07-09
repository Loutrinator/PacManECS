using Accessor;
using UnityEngine.AI;

namespace Modules {
    public class TargetEdibleModule : Module {
        public EdibleModule target;
        public NavMeshAgent navAgent;
        public override void Register() {
            TAccessor<TargetEdibleModule>.Instance.Add(this);
        }

        public override void Awake() {
            base.Awake();
            if (navAgent == null) {
                navAgent = GetComponent<NavMeshAgent>();
            }
        }
    }
}