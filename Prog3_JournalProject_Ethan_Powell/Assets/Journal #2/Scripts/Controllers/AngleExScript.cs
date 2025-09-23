using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleExScript : MonoBehaviour
{

    public List<float> angles;
    public float radius;
    public Vector2 circlePoint = Vector2.zero;
    float resetTimer;
    [Header("Time Properites")]
    public float resetTimerMax;

    private int indexer = 0;

    private void Start()
    {

        ResetAngles();

    }


    // Update is called once per frame
    void Update()
    {

        Vector2 targetPoint = circlePoint;

        float radians = angles[indexer] * Mathf.Deg2Rad;

        targetPoint += new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;

        if (Input.GetKeyDown(KeyCode.Space)) {

            indexer = (indexer + 1) % angles.Count;
        
        }

        Debug.DrawLine(circlePoint, targetPoint, Color.green);

        resetTimer += Time.deltaTime;

        if (resetTimer > resetTimerMax) {

            resetTimer = 0;
            ResetAngles();
        
        }
        
    }

    private void ResetAngles() { 
    
        angles.Clear();

        for (int i = 0; i < 10; i++)
        {

            angles.Add(Random.Range(0f, 360f));

        }

    }

}
