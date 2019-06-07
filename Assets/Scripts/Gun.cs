using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float shootInterval = 0.5f;

    private float timer = 0;

    public delegate void BulletDelegate(Bullet bullet);
    public event BulletDelegate OnShootBullet;

    public void SetShootInterval(float shootInterval)
    {
        this.shootInterval = shootInterval;
    }

    public void SetBulletPrefab(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shootInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        Vector3 randomShootPos = this.transform.position;
        randomShootPos.x += Random.Range(-0.5f, 0.5f);
        GameObject bullet = Instantiate(bulletPrefab, randomShootPos, bulletPrefab.transform.rotation) as GameObject;
        if(OnShootBullet != null)
        {
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            OnShootBullet(bulletComponent);
        }
    }
}
