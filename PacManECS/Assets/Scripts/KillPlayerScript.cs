using Accessor;
using Modules;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 10) {    // Player
            if (GameManager.Instance.isFruitActive) {    // self kill
                Destroy(gameObject);
            } else {    // Kill player
                GameManager.Instance.EndGame();
                Destroy(other.gameObject);
            }
        }
    }
}