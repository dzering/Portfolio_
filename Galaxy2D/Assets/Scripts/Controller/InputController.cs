using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Galaxy
{
    public class InputController
    {
        Camera camera;
        float vertical;
        float horizontal;
        bool fireWeapon;
        public Vector3 MousPosition { get; set; }
        public bool AccelerationOn { get; set; }
        public bool AccelerationOff { get; set; }
        public InputController(Camera camera)
        {
            this.camera = camera;
        }
        public bool FireWeapon
        {
            get { return fireWeapon; }
            set { fireWeapon = value; }
        }

        public float Horizontal
        {
            get { return horizontal; }
            set { horizontal = value; }
        }


        public float Vertical
        {
            get { return vertical; }
            set { vertical = value; }
        }


        public void Execute()
        {
            MousPosition = Input.mousePosition;
            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");
        
            FireWeapon = Input.GetButton("Fire1");
            AccelerationOn = Input.GetKeyDown(KeyCode.LeftShift);
            AccelerationOff = Input.GetKeyUp(KeyCode.LeftShift);
        }

    }
}