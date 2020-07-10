using Accessor;
using Modules;

namespace Updater {
    public class ScoreUpdater : IUpdater {
        public override void DoUpdate() {
            for (int i = 0; i < TAccessor<ScoreModule>.Instance.Modules.Count; ++i)
            {
                ScoreModule scoreModule = TAccessor<ScoreModule>.Instance.Modules[i];
                GameManager.Instance.score = scoreModule.score;
                scoreModule.tMPro.text = "SCORE\n" + scoreModule.score;
            }
        }
    }
}