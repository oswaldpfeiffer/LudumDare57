using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBaseClass<T> : MonoBehaviour where T : Component
{
    public static T Instance;

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            AwakeCustom();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void AwakeCustom ()
    {
    }
}
