using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class PlayerFollowTargetUpdater : IUpdater {
        public override void DoUpdate() {
            if (!GameManager.Instance.GameIsRunning) return;
            for (int i = 0; i < TAccessor<PlayerFollowTarget>.Instance.Modules.Count; ++i) {
                PlayerFollowTarget follower = TAccessor<PlayerFollowTarget>.Instance.Modules[i];

                GetClosestEnemy(follower);
                if (follower.target != null && GameManager.Instance.isFruitActive) {
                    TAccessor<TargetEdibleModule>.Instance.Get(follower).target = follower.target;
                }
            }
        }

        void GetClosestEnemy(PlayerFollowTarget follower) {
            float distance = float.MaxValue;
            follower.target = null;
            for (int i = TAccessor<FollowTarget>.Instance.Modules.Count - 1; i >= 0; --i) {
                FollowTarget enemy = TAccessor<FollowTarget>.Instance.Modules[i];
                float curDist = Vector3.Distance(enemy.transform.position, follower.transform.position);
                if (curDist < distance) {
                    distance = curDist;
                    follower.target = enemy;
                }
            }
        }
    }
}