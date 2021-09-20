using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public sealed class MoveToCircle : GameHandler
    {
        private float RotateSpeed = 5f;
        private float Radius = 0.1f;

        private Vector2 _centre;
        private float _angle;

        private void Start()
        {
            _centre = transform.position;
        }

        IEnumerator MoveCircle()
        {
            while(_angle < 360)
            {
                _angle += RotateSpeed * Time.deltaTime;

                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                transform.position = _centre + offset;

                yield return null;
            }
            base.Handle();
        }

        public override void Handle()
        {
            StartCoroutine(MoveCircle());
        }
    }
}