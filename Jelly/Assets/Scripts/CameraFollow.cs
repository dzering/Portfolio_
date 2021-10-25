using UnityEngine;

namespace Sausage
{
    internal sealed class CameraFollow
    {
        readonly Transform target;
        readonly Transform camera;
        float smoothCameraMove;
        Vector3 offset;

        public CameraFollow(Transform target, Transform camera, float smoothCameraMove)
        {
            this.target = target;
            this.camera = camera;
            this.smoothCameraMove = smoothCameraMove;
            offset = camera.position - target.position;
        }

        public void MoveCamera()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smootheadPosition = Vector3.Lerp(camera.position, desiredPosition, smoothCameraMove);
            camera.position = smootheadPosition;

        }
    }
}