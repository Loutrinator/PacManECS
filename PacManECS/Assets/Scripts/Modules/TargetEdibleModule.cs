﻿using Accessor;
using UnityEngine;
using UnityEngine.AI;

namespace Modules {
    public class TargetEdibleModule : Module {
        public GameObject target;
        public NavMeshAgent navAgent;
        public bool doChase;
        public override void Register() {
            TAccessor<TargetEdibleModule>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<TargetEdibleModule>.Instance.Remove(this);
        }

        public override void Awake() {
            base.Awake();
            if (navAgent == null) {
                navAgent = GetComponent<NavMeshAgent>();
            }
        }
    }
}