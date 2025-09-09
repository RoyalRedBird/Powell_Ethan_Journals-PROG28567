using System.Xml.Linq;
using UnityEngine;
using System.Collections;

public class LineMakerScript : MonoBehaviour
{

    private Vector2[] vectorIndex = new Vector2[999];
    private int currentIndex = 0;
    private float addVectorTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButton(0))
        {

            Debug.Log("Mouse is now held down.");

            addVectorTimer += Time.deltaTime;

            if(addVectorTimer >= 1)
            {

                vectorIndex[currentIndex] = mouseScreenPos;
                Debug.Log("Vector index " + currentIndex + " saved as " + mouseScreenPos);

                currentIndex++;

                addVectorTimer = 0;

            }

        }

        if(Input.GetMouseButtonUp(0))
        {

            addVectorTimer = 0;
            Debug.Log("Mouse is no longer being held down.");

        }

        if(currentIndex > 1) {

            Vector2 currentVector;
            Vector2 previousVector;

            float combinedMagnitude = 0;

            for (int i = 1; i < currentIndex; i++)
            {

                currentVector = vectorIndex[i];
                previousVector = vectorIndex[i - 1];

                Vector2 oldPlusNew = currentVector + previousVector;

                Debug.DrawLine(currentVector, previousVector, Color.red);
                combinedMagnitude += Mathf.Sqrt(Vector2.SqrMagnitude(currentVector + previousVector));

                Debug.Log("Manual magnitude is " + Mathf.Sqrt((Mathf.Pow(oldPlusNew.x, 2) + Mathf.Pow(oldPlusNew.y, 2))));

            }

            Debug.Log("The current combined magnitude of this line is " + combinedMagnitude);

        }

    }

}
