using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : IUpdater {
        public override void DoUpdate() {

            if (GameManager.Instance.GameIsRunning)
            {
                for (int i = TAccessor<TargetEdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                    TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];

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
                    if (distance < 0.5f) {
                        EatEdibleScript.EatEdible(TAccessor<ScoreModule>.Instance.Get(targetEdibleModule), edible);
                        return null;
                    }
                }
            }
            return target;
        }

        private ITarget ClosestEnemyModule(TargetEdibleModule targetEdibleModule) {
            float distance = float.MaxValue;
            ITarget target = null;
            for (int i = TAccessor<FollowTarget>.Instance.Modules.Count - 1; i >= 0; --i) {
                FollowTarget followTarget = TAccessor<FollowTarget>.Instance.Modules[i];
                //Debug.Log("Enemy found : " + followTarget.name);
                float curDist = Vector3.Distance(followTarget.transform.position, targetEdibleModule.transform.position);
                if (curDist < distance) {
                    distance = curDist;
                    target = followTarget;
                    //Debug.Log("target set to " + followTarget.name);
                    if (distance < 0.5f) {
                        //EatEdibleScript.EatEdible(TAccessor<ScoreModule>.Instance.Get(targetEdibleModule), target);
                        //Debug.Log("Enemy Eaten !");
                        return null;
                    }
                }
            }
            //Debug.Log("Closest Enemy : " + target.name);
            return target;
        }
        void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                for (int i = 0; i < TAccessor<TargetEdibleModule>.Instance.Modules.Count; ++i)
                {
                
                    TargetEdibleModule pacMan = TAccessor<TargetEdibleModule>.Instance.Modules[i];
                
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(pacMan.navAgent.destination, pacMan.transform.position);
                }
            }
        }
    }
}