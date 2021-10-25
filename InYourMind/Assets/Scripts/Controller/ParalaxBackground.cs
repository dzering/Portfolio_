using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    public Vector2 speedScroll;
    Transform cameraTransform;
    Vector3 position;
    Vector3 cameraPositionLast;
    float textureUnitSizeX;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraPositionLast = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width/sprite.pixelsPerUnit;
        position = transform.position;


    }

    // Update is called once per frame
    void LateUpdate()
    {

        var deltaCameraMove = cameraTransform.position - cameraPositionLast;
        transform.position += new Vector3(deltaCameraMove.x * speedScroll.x, deltaCameraMove.y * speedScroll.y);
        cameraPositionLast = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionx = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionx, transform.position.y);
        }
    }
}
