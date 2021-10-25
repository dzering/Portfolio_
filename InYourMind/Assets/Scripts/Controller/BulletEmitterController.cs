using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterController 
{
    List<BulletController> bullets = new List<BulletController>();
    Transform transform;

    int currentIndex;
    float timeTillNextBullet;

    const float delay = 1f;
    private const float startSpeed = 9f;

    public BulletEmitterController(List<ObjectView> bullets, Transform transform)
    {
        this.transform = transform;
        foreach (ObjectView bulletView in bullets)
        {
            this.bullets.Add(new BulletController(bulletView));
        }
    }


    public void Update()
    {
        if(timeTillNextBullet > 0)
        {
            bullets[currentIndex].Activate(false);
            timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            timeTillNextBullet = delay;
            bullets[currentIndex].ThrowBullet(transform.position, -transform.up * startSpeed);
            currentIndex++;
            if(currentIndex >= bullets.Count)
            {
                currentIndex = 0;
            }

        }
    }
}
