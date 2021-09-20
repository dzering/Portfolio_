using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ShipRotation : IRotation
{
    readonly Transform shipTransform;

    public ShipRotation(Transform transform)
    {
        shipTransform = transform;
    }

    public void Rotation(Vector3 direction)
    {
        var angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shipTransform.rotation = Quaternion.AngleAxis(angel - 90, Vector3.forward);
    }
}
