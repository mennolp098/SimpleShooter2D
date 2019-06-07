using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyOnLifetimeEnded : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = this.gameObject.GetComponent<ParticleSystem>();
        Destroy(this.gameObject, particleSystem.startLifetime);
    }
}
