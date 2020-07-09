using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAccessor<Type>
{
    private static TAccessor<Type> _instance;

    public static TAccessor<Type> Instance
    {
        get
        {
            if (_instance == null) _instance = new TAccessor<Type>();
            return _instance;
        }
    }
    private List<Type> modules;

    public List<Type> Modules => modules;

    public void Add(Type module)
    {
        modules.Add(module);
    }
}
