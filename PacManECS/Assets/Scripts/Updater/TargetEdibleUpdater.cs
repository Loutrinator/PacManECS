using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : IUpdater {
        public override void DoUpdate() {
            for (int i = TAccessor<FollowTarget>.Instance.Modules.Count - 1; i >= 0; --i) {
                print("in update");
                TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];
            }
        }
    }
}