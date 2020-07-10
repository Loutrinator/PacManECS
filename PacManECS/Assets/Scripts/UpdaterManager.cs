using System.Collections.Generic;
using UnityEngine;
using Updater;

public class UpdaterManager : MonoBehaviour {
    private static UpdaterManager _instance;

    public static UpdaterManager Instance {
        get {
            if (_instance == null) {
                _instance = new GameObject().AddComponent<UpdaterManager>();
                _instance.name = "UpdateManager";
            }
            return _instance;
        }
    }

    private List<IUpdater> _updaters = new List<IUpdater>();

    private void Awake() {
        if (_instance == null) _instance = this;
    }

    public void Add(IUpdater updater) {
        _updaters.Add(updater);
    }

    void Update() {
        for (int i = _updaters.Count - 1; i >= 0; --i) {
            _updaters[i].DoUpdate();
        }
    }
}