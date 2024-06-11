using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    public static CustomUpdateManager Instance;
    private HashSet<IUpdatable> updatables = new HashSet<IUpdatable>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        var updatablesCopy = new List<IUpdatable>(updatables);
        foreach (IUpdatable updatable in updatablesCopy)
            updatable.OnUpdate();
    }
    public void Register(IUpdatable updatable)
    {
        updatables.Add(updatable);
    }
    public void Unregister(IUpdatable updatable)
    {
        updatables.Remove(updatable);
    }
}