using Accessor;
using TMPro;

namespace Modules {
    public class ScoreModule : Module {
        public int score;
        public TextMeshProUGUI tMPro;
        public override void Register() {
            TAccessor<ScoreModule>.Instance.Add(this);
        }

        public override void Unregister() {
            TAccessor<ScoreModule>.Instance.Remove(this);
        }
    }
}
