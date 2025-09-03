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

        Debug.DrawLine(boxTopLeftCorner, boxTopRightCorner, Color.grey);
        Debug.DrawLine(boxTopRightCorner, boxBottomRightCorner, Color.grey);
        Debug.DrawLine(boxBottomRightCorner, boxBottomLeftCorner, Color.grey);
        Debug.DrawLine(boxBottomLeftCorner, boxTopLeftCorner, Color.grey);


        if(Input.mouseScrollDelta.y > 0)
        {

            boxSize += 0.1f;

        }

        if (Input.mouseScrollDelta.y < 0)
        {

            boxSize -= 0.1f;

        }

    }
}
