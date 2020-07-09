namespace Modules {
    public enum EdibleType {
        Point,
        Fruit
    }

    public class EdibleModule : Module {
        public EdibleType edibleType;

        public override void Register() {
            TAccessor<EdibleModule>.Instance.Add(this);
        }
    }
}