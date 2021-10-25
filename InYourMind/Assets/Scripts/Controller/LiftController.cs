using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController
{
    ObjectView liftView;
    ContactPooler contactPooler;
    SliderJoint2D sliderJoint2D;
    float speed;
    JointMotor2D sj2Dmotor;

    public LiftController(ObjectView view)
    {
        liftView = view;
        contactPooler = new ContactPooler(view.colliderObject);
        sliderJoint2D = view.GetComponent<SliderJoint2D>();
        sj2Dmotor = sliderJoint2D.motor;
    }
    public void Update()
    {
        contactPooler.Update();
        if (contactPooler.HasRigthContact)
        {
            sj2Dmotor.motorSpeed = -1;
            sliderJoint2D.motor = sj2Dmotor;
        }
        if (contactPooler.HasLeftContact)
        {
            sj2Dmotor.motorSpeed = 1;
            sliderJoint2D.motor = sj2Dmotor;
        }
    }
}
