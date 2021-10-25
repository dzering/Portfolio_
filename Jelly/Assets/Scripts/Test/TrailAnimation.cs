using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAnimation : MonoBehaviour
{
    public GameObject trail;
    public ParticleSystem mainParticle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            var child = trail.transform.GetChild(0).gameObject;
            child.SetActive(false);
            trail.SetActive(true);
            child.SetActive(true);

        }
        if(mainParticle.IsAlive() == false)
        {
            trail.SetActive(false);
        }
    }
}
