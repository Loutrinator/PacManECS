using Accessor;

namespace Modules {
    public class Entity : Module
    {
        public override void Register()
        {
            TAccessor<Entity>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<Entity>.Instance.Remove(this);
        }
    }
}
