using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField]
    private Color flashColor = Color.red;

    [SerializeField]
    private bool shouldFadeAway = true;

    [SerializeField]
    private float resetDuration = 1;

    private float resetTime = 0;
    private Camera cam;
    private Color originalColor;
    private float fadeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetComponent<Camera>();
        originalColor = cam.backgroundColor;
    }

    public void Flash()
    {
        cam.backgroundColor = flashColor;
        resetTime = resetDuration;
        fadeTime = 0;
    }

    private void Update()
    {
        if (resetTime > 0)
        {
            resetTime -= Time.deltaTime;
            if (shouldFadeAway)
            {
                fadeTime += Time.deltaTime / resetDuration;
                cam.backgroundColor = Color.Lerp(flashColor, originalColor, fadeTime);
            }
        }
        else
        {
            cam.backgroundColor = originalColor;
        }
    }
}
