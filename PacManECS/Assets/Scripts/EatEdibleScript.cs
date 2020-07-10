using Accessor;
using Modules;
using UnityEngine;

public class EatEdibleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 11) { // point/fruit
            var scoreModule = TAccessor<ScoreModule>.Instance.Get(this);
            var edible = other.gameObject.GetComponent<EdibleModule>();
            switch (edible.edibleType) {
                case EdibleType.Fruit:
                    scoreModule.score += 500;
                    GameManager.Instance.ActivateFruitMode();
                    break;
                case EdibleType.Point:
                    AudioManager.Instance.PlayEating();
                    scoreModule.score += 100;
                    break;
            }
            edible.Unregister();
            Destroy(edible.gameObject);
        }
    }
}