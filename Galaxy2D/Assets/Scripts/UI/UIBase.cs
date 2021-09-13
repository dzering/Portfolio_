using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal abstract class UIBase : MonoBehaviour
    {

        public static HealthBoard CreateHealthBoard(Health hp, Transform transform)
        {
            var healthBoard = Object.Instantiate(Resources.Load<HealthBoard>("UI/HealthBoard"));

            var healthBar = healthBoard.transform.GetChild(0).GetComponent<HealthBar>();
            healthBar.SetMaxHealth(hp);

            healthBoard.transform.SetParent(transform);
            healthBoard.transform.position = transform.position - new Vector3(0, GetBoundsOfCollider(transform), 0);

            return healthBoard;
        }

        static float GetBoundsOfCollider(Transform transform)
        {
            var bounds = transform.GetComponent<Collider2D>().bounds;
            return bounds.size.y;
        }
    }
}