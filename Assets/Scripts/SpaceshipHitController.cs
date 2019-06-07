using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHitController : MonoBehaviour
{
    [SerializeField]
    private Spaceship spaceship;

    [SerializeField]
    private HealthController healthController;

    // Start is called before the first frame update
    void Start()
    {
        spaceship.OnHitByTrash += RemoveHealth;
    }

    private void RemoveHealth(Spaceship spaceShip)
    {
        healthController.GetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
