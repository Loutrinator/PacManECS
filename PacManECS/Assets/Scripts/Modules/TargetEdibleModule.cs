namespace Modules {
    public class TargetEdibleModule : Module {
        public override void Register() {
            TAccessor<TargetEdibleModule>.Instance.Add(this);
        }
    }
}