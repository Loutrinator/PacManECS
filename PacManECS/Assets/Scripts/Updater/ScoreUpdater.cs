using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class ScoreUpdater : IUpdater {
        public override void DoUpdate() {
            for (int i = 0; i < TAccessor<ScoreModule>.Instance.Modules.Count; ++i)
            {
                ScoreModule scoreModule = TAccessor<ScoreModule>.Instance.Modules[i];
                scoreModule.tMPro.text = "Score : " + scoreModule.score;
            }
        }
    }
}