using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core Core { get; private set; }

    public virtual void Awake()
    {
        Core = transform.parent.GetComponent<Core>();
    }
}
