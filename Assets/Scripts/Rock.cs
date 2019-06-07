using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private float maxFallSpeed = 5;

    [SerializeField]
    private float minFallSpeed = 1;


    private float fallSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(new Vector3(0, 0, 1));

        Vector3 movement = (new Vector3(0, -1, 0) * fallSpeed * Time.deltaTime);
        this.transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Spaceship spaceShip = other.gameObject.GetComponent<Spaceship>();
        if (spaceShip != null)
        {
            spaceShip.GetHitBySpaceTrash();
            Destroy(this.gameObject);
        }
    }
}
