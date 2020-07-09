using UnityEngine;

namespace Updater {
    public abstract class IUpdater : MonoBehaviour {
        private void Awake() {
            UpdaterManager.Instance.Add(this);
        }

        public abstract void DoUpdate();
    }
}