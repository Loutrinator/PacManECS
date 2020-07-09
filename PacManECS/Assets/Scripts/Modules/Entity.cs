using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private void Awake()
    {
        TAccessor<Entity>.Instance.Add(this);
    }
}
