using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class HealthController 
    {
        Health HP;
        readonly Transform transform;
        HealthEntity healthEntity;
        HealthBoard healthBoarder;

        public HealthController(Health hp, Transform transform)
        {
            HP = hp;
            this.transform = transform;
            var gameObject = transform.gameObject.AddComponent<HealthEntity>();
            healthEntity = gameObject.GetComponent<HealthEntity>();
            healthEntity.HP = HP;
           // CreateHealthBoard(HP);
            healthBoarder = UIBase.CreateHealthBoard(HP, this.transform);
            // healthEntity.onCollision += healthBar.SetHealth;
            var healthBar = healthBoarder.transform.GetChild(0).GetComponent<HealthBar>();
            healthEntity.onCollision += healthBar.SetHealth;


            // HP = healthEntity.HP;
        }

        //HealthBoard CreateHealthBoard(Health hp)
        //{
        //    var healthBoard = Object.Instantiate(Resources.Load<HealthBoard>("UI/HealthBoard"));
        //    var healthBar = healthBoard.transform.GetChild(0).GetComponent<HealthBar>();
        //    healthBar.SetMaxHealth(HP);
        //    healthBoard.transform.SetParent(transform);
        //    healthBoard.transform.position = transform.position - new Vector3(0, GetBoundsOfCollider(), 0);
        //    healthEntity.onCollision += healthBar.SetHealth;

        //    return healthBoard;
        //}

        //float GetBoundsOfCollider()
        //{
        //    var bounds = transform.GetComponent<Collider2D>().bounds;
        //    return bounds.size.y;
        //}


    }
}