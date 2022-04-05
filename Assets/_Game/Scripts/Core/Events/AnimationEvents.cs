using UnityEngine;
using System;

public class AnimationEvents : MonoBehaviour
{
    public static AnimationEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action onWalkStart;
    public event Action onWalkEnd;

    public void WalkForward()
    {
        if(onWalkStart != null)
            onWalkStart();
    }

     public void Idle()
    {
        if(onWalkEnd != null)
            onWalkEnd();
    }
}
