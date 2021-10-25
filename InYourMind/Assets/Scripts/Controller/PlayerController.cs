using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    float xAxisInput;
    bool isJump;
    bool isMoving;


    float speed = 120f;
    float animationSpeed = 20f;
    float jumpSpeed = 4f;
    float movingTreshold = 0.1f;
    float jumpingTreshold = 1f;

    float gravity = -20f;
    float yVelocity;
    float xVelocity;
    //float groundLevel;

    Vector3 leftScale = new Vector3(-1, 1, 1);
    Vector3 rightScale = new Vector3(1, 1, 1);

    ObjectView view;
    SpriteAnimatorController spriteAnimator;
    ContactPooler contactPooler;


    public PlayerController(ObjectView player, SpriteAnimatorController animator)
    {
        view = player;
        spriteAnimator = animator;
        spriteAnimator.StartAnimation(view.spriteRenderer, StateAnim.Idle, true, speed);
        contactPooler = new ContactPooler(view.colliderObject);
    }


    void MoveTowards()
    {
        xVelocity = Time.fixedDeltaTime * speed * (xAxisInput < 0 ? -1 : 1);
        view.rigidbodyObject.velocity = view.rigidbodyObject.velocity.ChangeVector(x: xVelocity);
        view.transform.localScale = (xAxisInput < 0 ? leftScale : rightScale);

    }

    public void Update()
    {
        contactPooler.Update();
        spriteAnimator.Update();
        xAxisInput = Input.GetAxis("Horizontal");
        isJump = Input.GetAxis("Vertical") > 0;
        isMoving = Mathf.Abs(xAxisInput) > movingTreshold;

        if (isMoving)
        {
            MoveTowards();
        }

        if (contactPooler.IsGrouded)
        {
            spriteAnimator.StartAnimation(view.spriteRenderer, isMoving ? StateAnim.Run : StateAnim.Idle, true, animationSpeed);
            if(isJump && Mathf.Abs(view.rigidbodyObject.velocity.y) <= jumpingTreshold)
            {
                view.rigidbodyObject.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
        else
        {

            if(isJump && Mathf.Abs(view.rigidbodyObject.velocity.y) > jumpingTreshold)
            {
                spriteAnimator.StartAnimation(view.spriteRenderer, isMoving ? StateAnim.Jump : StateAnim.Idle, true, animationSpeed);
            }
        }
    }
}
