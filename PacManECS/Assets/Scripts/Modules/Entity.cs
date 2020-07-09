using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Module
{
    public override void Register()
    {
        TAccessor<Entity>.Instance.Add(this);
    }
}
