using UnityEngine;

public class HumanoidAnimationController : MonoBehaviour
{
    Animator charAnimator;

    void Start()
    {
        charAnimator = GetComponent<Animator>();
        AnimationEvents.current.onWalkStart += OnWalk;
        AnimationEvents.current.onWalkEnd += OnIdle;
    }

    void OnWalk()
    {
        charAnimator.SetTrigger("runTrigger");
    }

    void OnJump()
    {

    }

    void OnIdle()
    {
        charAnimator.SetTrigger("idleTrigger");
    }

    void OnDisable()
    {
        AnimationEvents.current.onWalkStart -= OnWalk;
        AnimationEvents.current.onWalkEnd -= OnIdle;
    }
}
