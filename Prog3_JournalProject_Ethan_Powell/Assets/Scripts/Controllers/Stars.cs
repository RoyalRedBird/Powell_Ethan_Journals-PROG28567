using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    float currentTime = 0;
    int transformIndexer = 0;

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        Vector2 targetPoint = Vector2.Lerp(starTransforms[transformIndexer].position, starTransforms[transformIndexer + 1].position, currentTime/drawingTime);
        Debug.DrawLine(starTransforms[transformIndexer].position, targetPoint, Color.white);

        if (currentTime >= drawingTime) { 
        
            transformIndexer++;
            currentTime = 0;

            if(transformIndexer == starTransforms.Count - 1)
            {

                transformIndexer = 0;

            }
        
        }

    }

}
