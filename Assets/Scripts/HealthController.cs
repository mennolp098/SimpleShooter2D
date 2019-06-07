using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private float health = 100;

    private float startWidth = 0;

    private float damage = 10;

    private void Start()
    {
        startWidth = healthBar.sizeDelta.x;
    }

    /// <summary>
    /// Get damage for now always 10.
    /// </summary>
    public void GetDamage()
    {
        health -= damage;
        healthBar.sizeDelta = healthBar.sizeDelta - new Vector2(startWidth/health*damage, 0);
    }
}
