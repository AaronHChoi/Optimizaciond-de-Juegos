using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    public static CustomUpdateManager Instance;
    private List<IUpdatable> updatables = new List<IUpdatable>();

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
        foreach (IUpdatable updatable in updatables)
            updatable.OnUpdate();
    }
    public void Register(IUpdatable updatable)
    {
        if (!updatables.Contains(updatable))
            updatables.Add(updatable);
    }
    public void Unregister(IUpdatable updatable)
    {
        if (updatables.Contains(updatable))
            updatables.Remove(updatable);
    }
}