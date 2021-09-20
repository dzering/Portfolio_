using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{

    internal sealed class Barrel : IFire
    {
        readonly Rigidbody2D projectilePref;
        readonly Transform pointProjectile;
        public BarrelProperties barrelProperty;
        float nextShotTime;

        public Barrel(Rigidbody2D projectilePref, Transform pointProjectile, BarrelProperties property)
        {
            this.projectilePref = projectilePref;
            this.pointProjectile = pointProjectile;
            barrelProperty = property;
        }


        public void Fire()
        {
            if(nextShotTime < Time.time)
            {
                var bullet = ProjectilePool.SharedInstance.GetProjectile();
                if(bullet != null)
                {
                    bullet.transform.position = pointProjectile.position;
                    bullet.transform.rotation = Quaternion.identity;
                    bullet.gameObject.SetActive(true);
                    bullet.GetComponent<Rigidbody2D>().AddForce(pointProjectile.transform.up * barrelProperty.Force);
                    nextShotTime = barrelProperty.TimeBetweenShot + Time.time;
                    bullet.transform.SetParent(null);
                }


                //var projectile = Object.Instantiate(projectilePref, pointProjectile.position, Quaternion.identity);
                //projectile.AddForce(pointProjectile.transform.up * barrelProperty.Force);
                //nextShotTime = barrelProperty.TimeBetweenShot + Time.time;
            }

        }
    }
}