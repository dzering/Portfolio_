using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class ScreenBounds
    {
        static Vector3 bounds;
       // public static Vector3 Bounds { get => bounds; set => bounds = value; }

        public ScreenBounds()
        {
            bounds = GetBounds();
        }


        public static Vector3 GetBounds()
        {
            var screenVector = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
            return Camera.main.ScreenToWorldPoint(screenVector);
        }

        public static Vector2 GetRandomPosition()
        {
            float horizontal = Random.Range(-bounds.x, bounds.x);
            float verticalPosition = Random.Range(-bounds.y, bounds.y);
            return new Vector2(horizontal, verticalPosition);
        }

        public static Vector2 GetRandomPosotionOutOfScreen()
        {
            float horizontal;
            float vertical;

            float horizontalLeft = Random.Range(-bounds.x * 1.1f, -bounds.x);
            float horizontalRight = Random.Range(bounds.x, bounds.x * 1.1f);
            vertical = Random.Range(-bounds.y, bounds.y);
            if (Random.value < 0.5f)
            {
                horizontal = horizontalLeft;
            }
            else
            {
                horizontal = horizontalRight;
            }

            var randomPointVertical = new Vector2(horizontal, vertical);

            float verticalBottom = Random.Range(-bounds.y * 1.1f, -bounds.y);
            float verticalTop = Random.Range(bounds.y, bounds.y * 1.1f);
            horizontal = Random.Range(-bounds.x, bounds.x);
            if (Random.value < 0.5f)
            {
                horizontal = horizontalLeft;
            }
            else
            {
                horizontal = horizontalRight;
            }

            var randomHorizontalPosition = new Vector2(horizontal, vertical);
            if (Random.value < 0.5f)
            {
                return randomHorizontalPosition;
            }
            else
            {
                return randomPointVertical;
            }
        }

        public static bool OutOfBounds(Vector2 position)
        {
            var x = Mathf.Abs(position.x);
            var y = Mathf.Abs(position.y);

            return (x > bounds.x || y > bounds.y);
        }
    }
}