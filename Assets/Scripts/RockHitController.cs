using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHitController : MonoBehaviour
{
    [SerializeField]
    private RockSpawner rockSpawner;

    public delegate void HittableDelegate(Hittable hittable);
    public event HittableDelegate OnRockHit;
    public event HittableDelegate OnRockDestroy;

    private void Start()
    {
        rockSpawner.OnRockSpawned += RegisterRockDelegates;
    }

    private void RegisterRockDelegates(Rock rock)
    {
        rock.gameObject.GetComponent<Hittable>().OnDestroy += ThrowOnRockDestroy;
        rock.gameObject.GetComponent<Hittable>().OnHit += ThrowOnRockHit;
    }

    private void ThrowOnRockDestroy(Hittable hittable)
    {
        if(OnRockDestroy != null)
        {
            OnRockDestroy(hittable);
        }
    }

    private void ThrowOnRockHit(Hittable hittable)
    {
        if (OnRockHit != null)
        {
            OnRockHit(hittable);
        }
    }
}
