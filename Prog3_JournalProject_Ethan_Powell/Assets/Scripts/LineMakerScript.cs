using System.Xml.Linq;
using UnityEngine;
using System.Collections;

public class LineMakerScript : MonoBehaviour
{

    private Vector2[] vectorIndex = new Vector2[999];
    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            vectorIndex[currentIndex] = mouseScreenPos;
            Debug.Log("Vector index " + currentIndex + " saved as " + mouseScreenPos);

            currentIndex++;

        }

        if(currentIndex > 1) {

            Vector2 currentVector;
            Vector2 nextVector;

            if(vectorIndex[currentIndex + 1] != null)
            {

                float combinedMagnitude = 0;

                for (int i = 0; i < currentIndex; i++)
                {

                    currentVector = vectorIndex[i];
                    nextVector = vectorIndex[i + 1];

                    Debug.DrawLine(currentVector, nextVector, Color.red);
                    combinedMagnitude += Mathf.Sqrt(Vector2.SqrMagnitude(currentVector + nextVector));

                }

                Debug.Log("The current combined magnitude of this line is " + combinedMagnitude);

            }         
        
        }

    }

}
