using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] float acceleration;
        [SerializeField] float speed;
        [SerializeField] float speedRotation;
        [SerializeField] Rigidbody2D projectilePref;
        [SerializeField] Transform prokectileStartPoint;
        [SerializeField] BarrelProperties barrelProperty;
        public static Player Instance { get; private set; }

        Camera cam;

        InputController inputController;
        PlayerShip ship;
        IFire barrel;


        void Awake()
        {
            inputController = new InputController(cam);
            barrel = new Barrel(projectilePref, prokectileStartPoint, barrelProperty);
            cam = Camera.main;
            var moveTransform = new AccelerationMove(acceleration, speed, transform);
            var rotationTransform = new ShipRotation(transform);


            ship = new PlayerShip(moveTransform, rotationTransform);
        }


        void Update()
        {
            inputController.Execute();
            var direction = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

            ship.Rotation(direction);
            ship.Move(inputController.Horizontal, inputController.Vertical);
            ship.AddAcceleration(inputController.AccelerationOn);
            ship.AddAcceleration(inputController.AccelerationOff);
            if (inputController.FireWeapon)
            {
                barrel.Fire();
            }
        }



    }

}