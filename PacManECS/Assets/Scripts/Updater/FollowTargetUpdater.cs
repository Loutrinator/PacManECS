using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetUpdater : MonoBehaviour
{
    
    void Update()
    {
        foreach (var module in TAccessor<FollowTarget>.Instance.Modules)
        {
            Vector3 dist = module.transform.position - module.target.transform.position;
        }
    }
}
