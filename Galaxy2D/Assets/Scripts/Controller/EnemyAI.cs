using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    enum State
    {
        Roaming,
        CheseTarget,
        GoingBackToStart
    }
    internal class EnemyAI : IEnemyAI
    {
        readonly IFire barrel;
        readonly Transform transform;
        readonly ShipProperties shipProperties;
        Vector2 roamPosition;
        GameObject player;
        Transform target;
        State state;

        public GameObject Player { 
            get
            {
                if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player");
                }
                else
                {
                    player = null;
                }
                return player;
            } 
        }

        public EnemyAI(Transform transform, ShipProperties shipProperties, IFire gun)
        {
            this.transform = transform;
            this.shipProperties = shipProperties;
            this.barrel = gun;
            roamPosition = ScreenBounds.GetRandomPosition();
            state = State.Roaming;

            if (Player)
            {
                target = Player.transform;
            }
 
        }

        public void Activate()
        {
            switch (state)
            {
                default:
                case State.Roaming:

                    float reachedPosition = 1f;
                    PathFinder(roamPosition);
                    Rotation(roamPosition);
                    if (Vector2.Distance(transform.position, roamPosition) < reachedPosition)
                    {
                        roamPosition = ScreenBounds.GetRandomPosition();
                    }
                    if (target)
                    {
                        FindeTarget();
                    }

                    break;

                case State.CheseTarget:

                    if (target)
                    {

                        PathFinder(target.position);
                        Atack();
                        float goingBackDistance = 5f;

                        if (Vector2.Distance(transform.position, target.position) > goingBackDistance)
                        {
                            state = State.GoingBackToStart;
                        }
                    }
                    else
                    {
                        state = State.GoingBackToStart;
                    }
                    break;

                case State.GoingBackToStart:
                    PathFinder(roamPosition);
                    state = State.Roaming;
                    break;
            }
        }

        void PathFinder(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, shipProperties.Speed * Time.deltaTime);
        }

        void FindeTarget()
        { 
            if(target)
            {
                float targetRange = 5f;
                if (Vector2.Distance(transform.position, target.position) < targetRange)
                {
                    state = State.CheseTarget;
                }
            }

        }

        void Atack()
        {
            Rotation(target.position);
            barrel.Fire();
        }

        void Rotation(Vector2 target)
        {
            Vector2 dir = target - (Vector2)transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * shipProperties.RotationSpeed);

        }
    }
}