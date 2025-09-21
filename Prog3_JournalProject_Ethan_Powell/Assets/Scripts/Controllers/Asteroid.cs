using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    [SerializeField] Vector2 currentWaypoint;
    [SerializeField] Vector2 currentDirection;

    private void Start()
    {
        
        SetWaypoint();

    }

    // Update is called once per frame
    void Update()
    {

        AsteroidMovement();

    }

    public void AsteroidMovement()
    {

        Vector3 velocity;

        velocity = currentDirection * moveSpeed * Time.deltaTime * -1;

        if (Vector3.Distance(transform.position, currentWaypoint) < arrivalDistance) { 
        
            SetWaypoint();
        
        }

        transform.position += velocity;

    }

    public void SetWaypoint()
    {

        currentDirection = Vector3.Normalize(new Vector2(Random.Range(1f, -1f), Random.Range(1f, -1f)));

        currentWaypoint = new Vector2((transform.position.x - (currentDirection.x * maxFloatDistance)), (transform.position.y - (currentDirection.y * maxFloatDistance)));

    }

}
