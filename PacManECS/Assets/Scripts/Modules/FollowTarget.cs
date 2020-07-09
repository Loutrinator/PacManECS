using System;
using System.Collections;
using System.Collections.Generic;
using Accessor;
using Modules;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : Module
{
    public Entity target;
    public NavMeshAgent navAgent;
    public override void Register()
    {
        TAccessor<FollowTarget>.Instance.Add(this);
    }

    public void Start()
    {
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
    }
}
