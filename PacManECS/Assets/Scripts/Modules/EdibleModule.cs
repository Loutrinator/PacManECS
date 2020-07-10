﻿using Accessor;

namespace Modules {
    public enum EdibleType {
        Point,
        Fruit
    }

    public class EdibleModule : ITarget {
        public EdibleType edibleType;

        public override void Register() {
            TAccessor<EdibleModule>.Instance.Add(this);
        }
    }
}