﻿using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : IUpdater {
        public override void DoUpdate() {
            if (!GameManager.Instance.GameIsRunning) return;
            for (int i = TAccessor<TargetEdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];
                
                if (!module.doChase) continue;

                if (GameManager.Instance.isFruitActive)
                {
                    //module.target = ClosestEnemyModule(module); //pour aller chercher les enemis
                    module.target = ClosestEdibleModule(module); //temporaire
                }
                else
                {
                    module.target = ClosestEdibleModule(module);
                }
                // Choose closest point
            
                if (module.target != null) {
                    //Debug.Log("Target = " + module.target.name);
                    module.navAgent.SetDestination(module.target.transform.position);
                    module.navAgent.isStopped = false;
                }
                else {
                    module.navAgent.isStopped = true;
                }
            }
        }

        private ITarget ClosestEdibleModule(TargetEdibleModule targetEdibleModule) {
            float distance = float.MaxValue;
            ITarget target = null;
            for (int i = TAccessor<EdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                EdibleModule edible = TAccessor<EdibleModule>.Instance.Modules[i];
                float curDist = Vector3.Distance(edible.transform.position, targetEdibleModule.transform.position);
                if (curDist < distance) {
                    distance = curDist;
                    target = edible;
                }
            }
            return target;
        }
    }
}