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
            if (_instance == null) {
                _instance = new TAccessor<Type> {_modules = new List<Type>()};
            }
            return _instance;
        }
    }
    private List<Type> _modules;

    public List<Type> Modules => _modules;

    public void Add(Type module)
    {
        _modules.Add(module);
    }

    public Type Get(MonoBehaviour module)
    {
        for (int i = 0; i < _modules.Count; i++)
        {
            var module2 = _modules[i];
            if (module2.gameObject.GetInstanceID() == module.gameObject.GetInstanceID())
            {
                return module2;
            }
        }
        return null;
    }
}
