using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{   
    [SerializeField]
    private float shakeDuration = 0.2f;

    private float shakeTimer = 0;
    
    [SerializeField]
    private float shakeMagnitude = 0.7f;
    
    Vector3 initialPosition;

    private void Start()
    {
        this.initialPosition = this.transform.localPosition;
    }

    public void Shake()
    {
        this.initialPosition = this.transform.localPosition;
        shakeTimer = shakeDuration;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = initialPosition;
        }
    }
}
