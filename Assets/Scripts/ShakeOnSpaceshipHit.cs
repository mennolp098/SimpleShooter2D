using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnSpaceshipHit : MonoBehaviour
{
    [SerializeField]
    private ScreenShake screenShake;

    [SerializeField]
    private Spaceship spaceship;

    private void Start()
    {
        spaceship.OnHitByTrash += ShakeScreen;
    }

    private void ShakeScreen(Spaceship spaceShip)
    {
        screenShake.Shake();
    }
}