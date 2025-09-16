using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    [Header("Motion Properties")]
    bool moveKeyDown;
    public float MaxSpeed;
    public float accellTime;
    public float decelSpeed;
    public float decelTime;
    Vector3 velocity = Vector3.zero;
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {

            StartCoroutine(SpawnBombAtOffset(new Vector2(Random.Range(-2f, 2f), Random.Range(-2f,2f))));

        }

        if (Input.GetKeyDown(KeyCode.T)) {

            TheNormalizer(new Vector2(3, 4));
            TheNormalizer(new Vector2(-3, 2));
            TheNormalizer(new Vector2(1.5f, 3.5f));

            deployBombTrail(3, 0.4f);

        }

        if (Input.GetKeyDown(KeyCode.N)) {

            SpawnBombAtCorner(2f);
        
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            WarpPlayer(enemyTransform, 1.5f);

        }

        DetectAsteroids(2.5f, asteroidTransforms);
        PlayerMovement();

    }

    void PlayerMovement()
    {

        moveKeyDown = false;

        if (Input.GetKey(KeyCode.LeftArrow)) {

            velocity.x -= (MaxSpeed / accellTime) * Time.deltaTime;
            moveKeyDown = true;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            velocity.x += (MaxSpeed / accellTime) * Time.deltaTime;
            moveKeyDown = true;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            velocity.y -= (MaxSpeed / accellTime) * Time.deltaTime;
            moveKeyDown = true;

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            velocity.y += (MaxSpeed / accellTime) * Time.deltaTime;
            moveKeyDown = true;

        }

        if (!moveKeyDown) {

            if (velocity.x > 0)
            {

                velocity.x -= (decelSpeed / decelTime) * Time.deltaTime;

            }
            else if (velocity.x < 0) {

                velocity.x += (decelSpeed / decelTime) * Time.deltaTime;

            }

            if (velocity.y > 0)
            {

                velocity.y -= (decelSpeed / decelTime) * Time.deltaTime;

            }
            else if (velocity.y < 0)
            {

                velocity.y += (decelSpeed / decelTime) * Time.deltaTime;

            }

        }

        Vector3.ClampMagnitude(velocity, MaxSpeed);

        //Clues were gathered from this forum post. https://discussions.unity.com/t/how-to-detect-screen-edge-in-unity/459224
        //It pointed out using Camera.WorldToScreenPoint to track where the ship is on screen and I thought it fitting.
        if (Camera.main.WorldToScreenPoint(transform.position + velocity).x >= Camera.main.pixelWidth || Camera.main.WorldToScreenPoint(transform.position + velocity).x <= 0) {

            velocity.x = 0;
        
        }

        if (Camera.main.WorldToScreenPoint(transform.position + velocity).y >= Camera.main.pixelHeight || Camera.main.WorldToScreenPoint(transform.position + velocity).y <= 0)
        {

            velocity.y = 0;

        }

        transform.position += velocity;

    }

    public IEnumerator SpawnBombAtOffset(Vector3 inOffset)
    {

        yield return new WaitForSeconds(3);

        print($"The passed vector3 is {inOffset}");

        Vector3 spawnLocation = transform.position + inOffset;

        GameObject newBomb = GameObject.Instantiate(bombPrefab, spawnLocation, Quaternion.identity);

        yield return null;

    }

    public void SpawnBombAtCorner(float inOffset)
    {

        int randomCorner = Random.Range(0, 4);
        print(randomCorner);

        Vector2 spawnLocation = transform.position;

        switch (randomCorner) {

            //Top Left
            case 0:
                spawnLocation = new Vector2(transform.position.x - inOffset, transform.position.y + inOffset);
                break;

            //Top Right
            case 1:
                spawnLocation = new Vector2(transform.position.x + inOffset, transform.position.y + inOffset);
                break;

            //Bottom Left
            case 2:
                spawnLocation = new Vector2(transform.position.x - inOffset, transform.position.y - inOffset);
                break;

            //Bottom Right
            case 3:
                spawnLocation = new Vector2(transform.position.x + inOffset, transform.position.y - inOffset);
                break;

        }      

        GameObject newBomb = GameObject.Instantiate(bombPrefab, spawnLocation, Quaternion.identity);

    }

    public void TheNormalizer(Vector2 testVector)
    {

        Vector2 normalizedVector = new Vector2(testVector.x / testVector.magnitude, testVector.y / testVector.magnitude);

        Vector2 verifyNormalize = testVector.normalized;

        print($"The manually normalized vector is {normalizedVector}, the automatically normalized vector is {verifyNormalize}.");

    }

    public void deployBombTrail(int numberOfBombs, float bombSpacing)
    {

        for(int i = 1; i <= numberOfBombs; i++)
        {

            Vector2 spawnLocation = transform.position +  (-transform.up * (i * bombSpacing));

            GameObject newBomb = GameObject.Instantiate(bombPrefab, spawnLocation, Quaternion.identity);

        }

    }

    public void WarpPlayer(Transform target, float ratio)
    {

        if(ratio > 1)
        {

            ratio = 1;

        }

        transform.position = Vector2.Lerp(transform.position, target.position, ratio);

    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {

        foreach(Transform spaceRock in inAsteroids)
        {

            float rockDistance = Vector3.Distance(transform.position, spaceRock.position);

            if(rockDistance <= inMaxRange)
            {

                Vector2 lineDirection = Vector3.Normalize(transform.position - spaceRock.position);

                Vector2 lineEndpoint = new Vector2((transform.position.x - (lineDirection.x * 2.5f)), (transform.position.y - (lineDirection.y * 2.5f)));

                Debug.DrawLine(transform.position, lineEndpoint, Color.green);

            }

        }

    }

}
