using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnRockDestroyAddScore : MonoBehaviour
{
    [SerializeField]
    private RockHitController rockHitController;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private float pointsPerDestroy = 10;

    private float score = 0;

    // Start is called before the  frame update
    void Start()
    {
        rockHitController.OnRockDestroy += AddScore;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void AddScore(Hittable hittable)
    {
        score += pointsPerDestroy;
        scoreText.text = "Score: " + score;
    }
}
