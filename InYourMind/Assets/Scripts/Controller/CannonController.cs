using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController
{
    Transform muzzleTransform;
    Transform targetTransform;

    Vector3 dir;
    float angel;
    Vector3 axes;

    public CannonController(Transform muzzle, Transform aimTransform)
    {
        muzzleTransform = muzzle;
        targetTransform = aimTransform;
    }
    public void Update()
    {
        dir = targetTransform.position - muzzleTransform.position;
        angel = Vector3.Angle(Vector3.down, dir);
        axes = Vector3.Cross(Vector3.down, dir);

        muzzleTransform.rotation = Quaternion.AngleAxis(angel, axes);
    }
}
