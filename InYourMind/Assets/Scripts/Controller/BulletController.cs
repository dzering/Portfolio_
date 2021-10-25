using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    Vector3 velocity;
    ObjectView view;

    public BulletController(ObjectView view)
    {
        this.view = view;
        Activate(false);
    }

    public void Activate(bool val)
    {
        view.gameObject.SetActive(val);
    }

    void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
        float angel = Vector3.Angle(Vector3.left, velocity);
        Vector3 axis = Vector3.Cross(Vector3.left, velocity);
        view.transform.rotation = Quaternion.AngleAxis(angel, axis);


    }
    public void ThrowBullet(Vector3 position, Vector3 velocity)
    {
        Activate(true);
        SetVelocity(velocity);
        view.transform.position = position;
        view.rigidbodyObject.velocity = Vector2.zero;
        view.rigidbodyObject.AddForce(velocity, ForceMode2D.Impulse);
    }
}
