using UnityEngine;

namespace Modules {
    public abstract class Module : MonoBehaviour
    {
        public abstract void Register();

        public abstract void Unregister();

        public virtual void Awake()
        {
            Register();
        }

        protected virtual void OnDestroy() {
            Unregister();
        }
    }
}
