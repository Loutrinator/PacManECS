using Accessor;
using TMPro;
using UnityEngine;

namespace Modules {
    public class ScoreModule : Module {
        public int score;
        public TextMeshProUGUI tMPro;
        public override void Register() {
            TAccessor<ScoreModule>.Instance.Add(this);
        }
    }
}
