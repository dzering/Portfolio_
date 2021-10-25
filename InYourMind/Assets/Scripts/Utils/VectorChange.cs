using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorChange
{
    public static Vector3 ChangeVector(this Vector3 v3, object x = null, object y = null, object z = null)
    {
        return new Vector3(x == null ? v3.x : (float)x, y == null ? v3.y : (float)y, z == null ? v3.z : (float)z);
    }

    public static Vector2 ChangeVector(this Vector2 v3, object x = null, object y = null)
    {
        return new Vector2(x == null ? v3.x : (float)x, y == null ? v3.y : (float)y);
    }
}
