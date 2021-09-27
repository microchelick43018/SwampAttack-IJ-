using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationState : State
{
    private void OnEnable()
    {
        Animator.Play("Celebration");
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }
}
