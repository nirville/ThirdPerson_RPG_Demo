using System;
using UnityEngine;

public class InputEvents : MonoBehaviour
{
    public event EventHandler OnPointerInputDown;
    public event EventHandler OnPointerInputContinue;
    public event EventHandler OnPointerInputReleased;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        #region EDITOR
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            OnPointerInputDown?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetMouseButton(0))
        {
            OnPointerInputContinue?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnPointerInputReleased?.Invoke(this, EventArgs.Empty);
        }
#endif
        #endregion

        #region HANDHELD_DEVICE
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnPointerInputDown?.Invoke(this, EventArgs.Empty);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                OnPointerInputContinue?.Invoke(this, EventArgs.Empty);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                OnPointerInputReleased?.Invoke(this, EventArgs.Empty);
            }
        }
#endif

#if UNITY_IOS
    if(Input.touchCount > 0)
    {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnPointerInputDown?.Invoke(this, EventArgs.Empty);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                OnPointerInputContinue?.Invoke(this, EventArgs.Empty);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                OnPointerInputReleased?.Invoke(this, EventArgs.Empty);
            }
    }
#endif

        #endregion
    }
}