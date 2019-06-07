using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed;

    public delegate void SpaceshipDelegate(Spaceship spaceship);
    public event SpaceshipDelegate OnHitByTrash;

    /// <summary>
    /// Triggers when spacetrash hits this object.
    /// </summary>
    public void GetHitBySpaceTrash()
    {
        if(OnHitByTrash != null)
        {
            OnHitByTrash(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Physics Update
    /// </summary>
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rigidBody.AddForce(movement * speed);
    }
}
