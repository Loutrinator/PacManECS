using Accessor;
using UnityEngine;

namespace Updater {
    public class FollowTargetUpdater : IUpdater
    {
        public override void DoUpdate()
        {
            for (int i = 0; i < TAccessor<FollowTarget>.Instance.Modules.Count; i++)
            {
                FollowTarget module = TAccessor<FollowTarget>.Instance.Modules[i];
                Vector3 dist = module.transform.position - module.target.transform.position;
                var entity = TAccessor<Entity>.Instance.Get(module);
            }
        }
    }
}
