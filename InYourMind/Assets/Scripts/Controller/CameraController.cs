using UnityEngine;

public class CameraController
{
    float offsetX = 1.5f;
    float offsetY = 1.5f;

    int camSpeed = 5;
    Transform playerTransform;
    Transform cameraTransform;

    public CameraController(Transform player, Transform camera)
    {
        playerTransform = player;
        cameraTransform = camera;
    }

    // Update is called once per frame
    public void Update()
    {
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, 
            new Vector3(playerTransform.position.x + offsetX, playerTransform.position.y + offsetY, cameraTransform.position.z), Time.deltaTime * camSpeed);
    }

}
