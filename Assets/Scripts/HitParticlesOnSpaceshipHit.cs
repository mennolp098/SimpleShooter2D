using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticlesOnSpaceshipHit : MonoBehaviour
{
    [SerializeField]
    private Spaceship spaceship;

    [SerializeField]
    private GameObject hitParticles;

    // Start is called before the  frame update
    void Start()
    {
        spaceship.OnHitByTrash += SpawnParticles;
    }
    
    void SpawnParticles(Spaceship spaceship)
    {
        Instantiate(hitParticles, spaceship.transform.position, hitParticles.transform.rotation);
    }
}
