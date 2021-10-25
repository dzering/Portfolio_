using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sausage
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Player player;
        [SerializeField] Trajectory trajectory;
        [SerializeField] float pushForce;
        HandController direction;

        [SerializeField] Transform cameraTransform;
        [SerializeField] float smoothCamera = 0.125f;
        CameraFollow cameraFollow;
        Camera cam;

        bool isDragging;
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            var playerTransform = player.GetComponent<Transform>();
            direction = new HandController();
            cameraFollow = new CameraFollow(playerTransform, cameraTransform, smoothCamera);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
            }
        }
        private void FixedUpdate()
        {
            cameraFollow.MoveCamera();
        }

        void OnDragStart()
        {
            direction.StartPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            trajectory.Show();
        }

        void OnDrag()
        {
            direction.EndPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            trajectory.UpdateDots(player.Pos, direction.PushForce(pushForce));
        }

        void OnDragEnd()
        {
            var push = direction.PushForce(pushForce);
            push.z = 0;
            player.playerMove.Push(push);
            trajectory.Hide();
        }
    }
}