using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
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

        }

    }

    public IEnumerator SpawnBombAtOffset(Vector3 inOffset)
    {

        yield return new WaitForSeconds(3);

        print($"The passed vector3 is {inOffset}");

        Vector3 spawnLocation = transform.position + inOffset;

        GameObject newBomb = GameObject.Instantiate(bombPrefab, spawnLocation, Quaternion.identity);

        yield return null;

    }

    public void TheNormalizer(Vector2 testVector)
    {

        Vector2 normalizedVector = new Vector2(testVector.x / testVector.magnitude, testVector.y / testVector.magnitude);

        Vector2 verifyNormalize = testVector.normalized;

        print($"The manually normalized vector is {normalizedVector}, the automatically normalized vector is {verifyNormalize}.");

    }

}
