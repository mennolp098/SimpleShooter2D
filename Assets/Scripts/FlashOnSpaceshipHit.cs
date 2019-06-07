using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnSpaceshipHit : MonoBehaviour
{
    [SerializeField]
    private ScreenFlash screenFlash;

    [SerializeField]
    private Spaceship spaceship;

    private void Start()
    {
        spaceship.OnHitByTrash += FlashScreen;
    }

    private void FlashScreen(Spaceship spaceShip)
    {
        screenFlash.Flash();
    }
}
