using Modules;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EatEdibleScript : MonoBehaviour
{
    public void EatEdible(ScoreModule scoreModule, EdibleModule edible) {
        switch (edible.edibleType) {
            case EdibleType.Fruit:
                scoreModule.score += 500;
                break;
            case EdibleType.Point:
                scoreModule.score += 100;
                break;
        }
    }
}