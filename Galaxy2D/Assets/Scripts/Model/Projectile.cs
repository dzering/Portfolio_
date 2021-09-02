using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class Projectile : MonoBehaviour, IDamaging
    {
        [SerializeField] float damage;
        Transform rootPool;
        public Transform RootPool { 
            get
            {
                if(rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    rootPool = find == null ? null : find.transform;
                }
                return rootPool;
            } 
        }
        public float ForceDamage
        {
            get { return damage; }
            set { damage = value; }
        }

        private void Update()
        {
            BoundsCheking();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPool();
            //Destroy(gameObject);
        }

        void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);
            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }

        private void BoundsCheking()
        {
            if (ScreenBounds.OutOfBounds(transform.position))
            {
                ReturnToPool();
            }
        }

    }
}