using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class HealthBoard : UIBase
    {
        Vector3 direcion;
        Transform target;

       // public HealthBar HealthBar;


        private void Start()
        {
            target = GetComponent<Transform>().parent;
            direcion = target.position - GetComponent<Transform>().position;
            //HealthBar = gameObject.GetComponent<HealthBar>();
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            transform.position = new Vector3(target.position.x, target.position.y - direcion.y, 0);

        }


    }
}