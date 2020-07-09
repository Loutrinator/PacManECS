using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Entity target;
    private void Awake()
    {
        TAccessor<FollowTarget>.Instance.Add(this);
    }
}
