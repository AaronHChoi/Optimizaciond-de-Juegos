using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    public static CustomUpdateManager instance;
    private List<IUpdatable> updatables = new List<IUpdatable>();

    public static CustomUpdateManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("UpdateManager");
                instance = obj.AddComponent<CustomUpdateManager>();
            }
            return instance;
        }
    }
    private void Update()
    {
        foreach(IUpdatable updatable in updatables)
            updatable.OnUpdate();
    }
    public void Register(IUpdatable updatable)
    {
        if(!updatables.Contains(updatable))
            updatables.Add(updatable);
    }
    public void Unregister(IUpdatable updatable)
    {
        if (updatables.Contains(updatable))
            updatables.Remove(updatable);
    }
}