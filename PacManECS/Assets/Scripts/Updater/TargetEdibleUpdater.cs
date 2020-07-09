using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : IUpdater {
        public override void DoUpdate() {
            for (int i = TAccessor<TargetEdibleModule>.Instance.Modules.Count - 1; i >= 0; --i) {
                Debug.Log(i);
                TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];
            }
        }
    }
}