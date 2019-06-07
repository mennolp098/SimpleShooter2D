using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlareOnGunShoot : MonoBehaviour
{
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject hitParticles;

    // Start is called before the  frame update
    void Start()
    {
        gun.OnShootBullet += SpawnParticles;
    }

    void SpawnParticles(Bullet bullet)
    {
        Instantiate(hitParticles, bullet.transform.position, hitParticles.transform.rotation);
    }
}
