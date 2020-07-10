using Accessor;

namespace Modules {
    public class PlayerFollowTarget : ITarget
    {
        public ITarget target;
        
        public override void Register()
        {
            TAccessor<PlayerFollowTarget>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<PlayerFollowTarget>.Instance.Remove(this);
        }
    }
}
