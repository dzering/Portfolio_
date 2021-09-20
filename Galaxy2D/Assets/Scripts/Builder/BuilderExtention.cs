using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class BuilderExtention
{
    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        return gameObject;
    }

    public static GameObject AddRigidbody(this GameObject gameObject, float mass)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody2D>();
        component.mass = mass;
        component.gravityScale = 0;
        return gameObject;
        
    }

    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return gameObject;

    }

    private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var result = gameObject.GetComponent<T>();
        if (!result)
        {
           result = gameObject.AddComponent<T>();
        }
        return result;
    }

}
