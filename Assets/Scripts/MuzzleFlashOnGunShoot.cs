using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashOnGunShoot : MonoBehaviour
{
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject flash;

    // Start is called before the  frame update
    void Start()
    {
        gun.OnShootBullet += SpawnFlash;
    }

    void SpawnFlash(Bullet bullet)
    {
        Instantiate(flash, bullet.transform.position + new Vector3(0, 0, -7), flash.transform.rotation);
    }
}
