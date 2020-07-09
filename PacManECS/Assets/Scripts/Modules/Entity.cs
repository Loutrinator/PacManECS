using Accessor;

namespace Modules {
    public class Entity : Module
    {
        public override void Register()
        {
            TAccessor<Entity>.Instance.Add(this);
        }
    }
}
