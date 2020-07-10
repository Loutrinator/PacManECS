using Accessor;
using Modules;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 10) {    // Player
            if (GameManager.Instance.isFruitActive) {    // self kill
                FollowTarget followTarget = TAccessor<FollowTarget>.Instance.Get(this);
                followTarget.Unregister();
                Destroy(gameObject);
            } else {    // Kill player
                TargetEdibleModule targetEdible = other.gameObject.GetComponent<TargetEdibleModule>();
                PlayerFollowTarget playerFollowTarget = other.gameObject.GetComponent<PlayerFollowTarget>();
                ScoreModule scoreModule = other.gameObject.GetComponent<ScoreModule>();
                targetEdible.Unregister();
                playerFollowTarget.Unregister();
                scoreModule.Unregister();
                GameManager.Instance.EndGame();
                Destroy(targetEdible.gameObject);
            }
        }
    }
}