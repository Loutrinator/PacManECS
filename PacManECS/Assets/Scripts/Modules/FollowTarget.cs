using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : Module
{
    public Entity target;
    public override void Register()
    {
        TAccessor<FollowTarget>.Instance.Add(this);
        this.r
    }
}
