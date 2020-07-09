using System;
using System.Collections;
using System.Collections.Generic;
using Accessor;
using Modules;
using UnityEngine;

public class Entity : Module
{
    public override void Register()
    {
        TAccessor<Entity>.Instance.Add(this);
    }
}
