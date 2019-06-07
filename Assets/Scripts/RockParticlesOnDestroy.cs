using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockParticlesOnDestroy : MonoBehaviour
{
    [SerializeField]
    private RockHitController rockHitController;

    [SerializeField]
    private GameObject rockParticles;

    // Start is called before the  frame update
    void Start()
    {
        rockHitController.OnRockDestroy += SpawnRockParticles;
    }

    // Update is called once per frame
    void SpawnRockParticles(Hittable hittable)
    {
        Instantiate(rockParticles, hittable.transform.position, rockParticles.transform.rotation);
    }
}
