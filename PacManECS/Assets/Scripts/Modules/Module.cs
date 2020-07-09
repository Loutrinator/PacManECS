using UnityEngine;

namespace Modules {
    public abstract class Module : MonoBehaviour
    {
        public abstract void Register();

        public virtual void Awake()
        {
            Register();
        }
    }
}
