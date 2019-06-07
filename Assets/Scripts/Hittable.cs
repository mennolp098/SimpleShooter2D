using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 30;

    [SerializeField]
    private float minHealth = 10;

    private float health = 20;

    public delegate void HittableDelegate(Hittable hittable);
    public event HittableDelegate OnDestroy;
    public event HittableDelegate OnHit;

    /// <summary>
    /// Triggers when it got hit by something that handles this component.
    /// </summary>
    /// <param name="damage">damage output done by component</param>
    public void GetHit(float damage)
    {
        this.health -= damage;
        if(OnHit != null)
        {
            OnHit(this);
        }
        if(this.health <= 0)
        {
            if(OnDestroy != null)
            {
                OnDestroy(this);
            }
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.health = Random.Range(minHealth, maxHealth);

    }
}
