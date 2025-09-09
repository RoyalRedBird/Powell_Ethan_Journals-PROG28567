using UnityEngine;

public class SquareSpawner : MonoBehaviour
{

    [SerializeField] GameObject boxObject;
    private float boxSize = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 boxTopLeftCorner = new Vector2(mouseScreenPos.x - boxSize, mouseScreenPos.y + boxSize);
        Vector2 boxTopRightCorner = new Vector2(mouseScreenPos.x + boxSize, mouseScreenPos.y + boxSize);
        Vector2 boxBottomLeftCorner = new Vector2(mouseScreenPos.x - boxSize, mouseScreenPos.y - boxSize);
        Vector2 boxBottomRightCorner = new Vector2(mouseScreenPos.x + boxSize, mouseScreenPos.y - boxSize);

        Color boxColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

        Debug.DrawLine(boxTopLeftCorner, boxTopRightCorner, boxColor);
        Debug.DrawLine(boxTopRightCorner, boxBottomRightCorner, boxColor);
        Debug.DrawLine(boxBottomRightCorner, boxBottomLeftCorner, boxColor);
        Debug.DrawLine(boxBottomLeftCorner, boxTopLeftCorner, boxColor);


        if(Input.mouseScrollDelta.y > 0)
        {

            boxSize += 0.1f;

        }

        if (Input.mouseScrollDelta.y < 0)
        {

            boxSize -= 0.1f;

        }

        if(Input.GetMouseButtonDown(0))
        {

            GameObject spawnedBox = GameObject.Instantiate(boxObject);

            spawnedBox.transform.position = mouseScreenPos;
            spawnedBox.GetComponent<BoxScript>().SetBoxSize(boxSize);

        }

    }
}
