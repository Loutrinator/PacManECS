using UnityEngine;

namespace Modules {
    public abstract class Module : MonoBehaviour
    {
        public abstract void Register();
        //TODO: Unregister

        public abstract void Unregister();

        public virtual void Awake()
        {
            Register();
        }
    }
}
