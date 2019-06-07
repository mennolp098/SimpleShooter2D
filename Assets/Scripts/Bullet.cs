using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float damage;

    private float destroyTimer = 0;
    private float timeToDestroy = 2;

    /// <summary>
    /// Set speed of this bullet
    /// </summary>
    /// <param name="speed">New speed</param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// Set the damage of this bullet.
    /// </summary>
    /// <param name="damage">New damage</param>
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    /// <summary>
    /// Get the damage of this bullet.
    /// </summary>
    /// <returns>Damage output of bullet</returns>
    public float GetDamage()
    {
        return this.damage;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckDestroy();
    }

    /// <summary>
    /// Checks if this bullet should destroy itself.
    /// </summary>
    private void CheckDestroy()
    {
        this.destroyTimer += Time.deltaTime;
        if (this.destroyTimer >= this.timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Movement of bulet.
    /// </summary>
    private void Movement()
    {
        Vector3 movement = (new Vector3(0, 1, 0) * speed * Time.deltaTime);
        this.transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // We are hitting something with the component hittable
        Hittable hittableObject = collision.gameObject.GetComponent<Hittable>();
        Debug.Log("Hitting object: " + collision.name + " " + hittableObject);
        if (hittableObject != null)
        {
            hittableObject.GetHit(damage);
            Destroy(this.gameObject);
        }
    }
}
