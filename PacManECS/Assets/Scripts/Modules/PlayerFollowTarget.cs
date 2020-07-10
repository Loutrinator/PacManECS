using Accessor;
using UnityEngine;

namespace Modules {
    public class PlayerFollowTarget : Module
    {
        public GameObject target;
        
        public override void Register()
        {
            TAccessor<PlayerFollowTarget>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<PlayerFollowTarget>.Instance.Remove(this);
        }
    }
}
