using Accessor;
using Modules;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    public static void KillPlayer(TargetEdibleModule targetEdible) {
        TAccessor<TargetEdibleModule>.Instance.Remove(targetEdible);
        GameManager.Instance.EndGame();
        Destroy(targetEdible.gameObject);
    }
}