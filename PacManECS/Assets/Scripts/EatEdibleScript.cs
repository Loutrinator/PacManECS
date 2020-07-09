using Accessor;
using Modules;
using UnityEngine;

public class EatEdibleScript : MonoBehaviour
{
    public static void EatEdible(ScoreModule scoreModule, EdibleModule edible) {
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
        TAccessor<EdibleModule>.Instance.Remove(edible);
        Destroy(edible.gameObject);
    }
}