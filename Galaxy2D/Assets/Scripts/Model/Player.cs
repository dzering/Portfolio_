using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] Health health;
        [SerializeField] float acceleration;
        [SerializeField] float speed;
        [SerializeField] float speedRotation;
        [SerializeField] Rigidbody2D projectilePref;
        [SerializeField] Transform projectileStartPoint;
        [SerializeField] BarrelProperties barrelProperty;

        HealthController healthController;
        public static Transform Instance { get; private set; }

        Camera cam;

        InputController inputController;
        PlayerShip ship;
        Barrel barrel;


        void Awake()
        {
            inputController = new InputController(cam);
            barrel = new Barrel(projectilePref, projectileStartPoint, barrelProperty);
            cam = Camera.main;
            var moveTransform = new AccelerationMove(acceleration, speed, transform);
            var rotationTransform = new ShipRotation(transform);

            Instance = transform;
            ship = new PlayerShip(moveTransform, rotationTransform);

            healthController = new HealthController(health, transform);

            // Atack modifier by Chain of Responsibility;

            var modidier = new PlayerModifier(barrel.barrelProperty);
            modidier.Add(new AtackPlayerModifier(barrelProperty, 500, 0.05f));
            modidier.Handle();

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