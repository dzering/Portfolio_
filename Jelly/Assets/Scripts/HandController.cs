using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sausage
{
    internal sealed class HandController
    {
        public Vector3 StartPosition;
        public Vector3 EndPosition;

        public Vector3 PushForce(float pushForce)
        {
            Vector3 direction = (StartPosition - EndPosition).normalized;
            float distance = Vector3.Distance(StartPosition, EndPosition);
            return  direction * distance * pushForce;
        }
    }
}