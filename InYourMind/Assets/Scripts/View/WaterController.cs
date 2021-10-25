using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController
{
    float speedAnimation = 10f;
    ObjectView waterView;
    SpriteAnimatorController animator;


public WaterController(ObjectView view, SpriteAnimatorController animator)
    {
        waterView = view;
        this.animator = animator;
        animator.StartAnimation(waterView.spriteRenderer, StateAnim.Run, true, speedAnimation);
    }
}
