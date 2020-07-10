using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class PlayerFollowTargetUpdater : IUpdater {
        public float detectionDistance = 10f;
        public override void DoUpdate() {
            if (!GameManager.Instance.GameIsRunning) return;
            for (int i = 0; i < TAccessor<PlayerFollowTarget>.Instance.Modules.Count; ++i) {
                PlayerFollowTarget follower = TAccessor<PlayerFollowTarget>.Instance.Modules[i];

                GetClosestEnemy(follower);
                if (follower.target != null /*&& GameManager.Instance.isFruitActive*/) {
                    RefreshTargetDestination(follower);
                    TAccessor<TargetEdibleModule>.Instance.Get(follower).doChase = false;
                } else {
                    TAccessor<TargetEdibleModule>.Instance.Get(follower).doChase = true;
                }
            }
        }

        void GetClosestEnemy(PlayerFollowTarget follower) {
            float distance = float.MaxValue;
            follower.target = null;
            for (int i = TAccessor<FollowTarget>.Instance.Modules.Count - 1; i >= 0; --i) {
                FollowTarget enemy = TAccessor<FollowTarget>.Instance.Modules[i];
                float curDist = Vector3.Distance(enemy.transform.position, follower.transform.position);
                if (curDist < distance && curDist < detectionDistance) {
                    distance = curDist;
                    follower.target = TAccessor<ITarget>.Instance.Get(enemy);
                }
            }
        }
    }
}