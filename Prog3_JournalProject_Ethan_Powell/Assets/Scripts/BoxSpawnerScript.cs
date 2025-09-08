using UnityEngine;
using TMPro;


public class BoxSpawnerScript : MonoBehaviour
{

    private int boxesToRender = 0;
    [SerializeField] TMP_InputField boxInputField;
    [SerializeField] GameObject boxPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateRenderCount()
    {

        int newCount = int.Parse(boxInputField.text);

        Debug.Log("Boxes to render: " + newCount);

        if(newCount > 0 && newCount <= 9 ) {

            boxesToRender = newCount;

            for (int i = 1; i <= boxesToRender; i++)
            {

                GameObject newBox = GameObject.Instantiate(boxPrefab);
                Vector2 currentLocation = transform.position;
                currentLocation.x = currentLocation.x + (1.5f * i);

                newBox.transform.position = currentLocation;

            }

        }
        else
        {

            Debug.Log("This is not a valid number of boxes.");

        }       

    }

}
