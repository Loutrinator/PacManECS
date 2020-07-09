using Modules;
using UnityEngine;

namespace Updater {
    public class TargetEdibleUpdater : MonoBehaviour {
        void Update() {
            for (int i = TAccessor<FollowTarget>.Instance.Modules.Count - 1; i >= 0; i--) {
                TargetEdibleModule module = TAccessor<TargetEdibleModule>.Instance.Modules[i];
            }
        }
    }
}