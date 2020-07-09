using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EdibleType{point,fruit}
public class EdibleModule : Module
{
    public EdibleType edibleType;
    public override void Register()
    {
        TAccessor<EdibleModule>.Instance.Add(this);
    }
}
