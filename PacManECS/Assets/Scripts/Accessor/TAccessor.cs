using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TAccessor<Type>  where Type : Module 
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

    public Type Get(MonoBehaviour module)
    {
        for (int i = 0; i < modules.Count; i++)
        {
            var module2 = modules[i];
            if (module2.gameObject.GetInstanceID() == module.gameObject.GetInstanceID())
            {
                return module2;
            }
        }
        return null;
    }
}
