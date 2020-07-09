using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : IUpdater {
        public override void DoUpdate() {
            for (int i = TAccessor<TargetEdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];
                
                // Choose closest point
                module.target = ClosestEdibleModule(module);
                
                if (module.target != null) {
                    module.navAgent.SetDestination(module.target.transform.position);
                    module.navAgent.isStopped = false;
                }
                else {
                    module.navAgent.isStopped = true;
                }
            }
        }

        private EdibleModule ClosestEdibleModule(TargetEdibleModule targetEdibleModule) {
            float distance = float.MaxValue;
            EdibleModule target = null;
            for (int i = TAccessor<EdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                EdibleModule edible = TAccessor<EdibleModule>.Instance.Modules[i];
                float curDist = Vector3.Distance(edible.transform.position, targetEdibleModule.transform.position);
                if (curDist < distance) {
                    distance = curDist;
                    target = edible;
                    if (distance < 0.5f) {
                        EatEdibleScript.EatEdible(TAccessor<ScoreModule>.Instance.Get(targetEdibleModule), target);
                        return null;
                    }
                }
            }
            return target;
        }
    }
}