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
                targetEdible.Unregister();
                GameManager.Instance.EndGame();
                Destroy(targetEdible.gameObject);
            }
        }
    }
}