using Accessor;
using Modules;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    public static void KillPlayer(TargetEdibleModule targetEdible) {
        targetEdible.Unregister();
        GameManager.Instance.EndGame();
        Destroy(targetEdible.gameObject);
    }
}