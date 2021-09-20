using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public class MoveToPosition : GameHandler
    {
        [SerializeField] Vector3 positionToMove;
        [SerializeField] float speed;

        IEnumerator StartMove()
        {
            while((transform.position - positionToMove).sqrMagnitude > 0.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, positionToMove, speed * Time.deltaTime);

                yield return null;
            }
            base.Handle();
        }

        public override void Handle()
        {
            StartCoroutine(StartMove());

        }
    }
}