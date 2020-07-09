using UnityEngine;

namespace Modules {
    public abstract class Module : MonoBehaviour
    {
        public abstract void Register();

        public void Awake()
        {
            Register();
        }
    }
}
