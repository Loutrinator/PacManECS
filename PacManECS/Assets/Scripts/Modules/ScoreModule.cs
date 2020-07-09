using UnityEngine;

namespace Modules {
    public class ScoreModule : Module {
        public int score;
        public override void Register() {
            TAccessor<ScoreModule>.Instance.Add(this);
        }
    }
}
