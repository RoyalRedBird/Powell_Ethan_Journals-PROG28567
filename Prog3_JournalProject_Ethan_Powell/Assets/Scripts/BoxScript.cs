using UnityEngine;

public class BoxScript : MonoBehaviour
{

    private float boxSize = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 boxTopLeftCorner = new Vector2(transform.position.x - boxSize, transform.position.y + boxSize);
        Vector2 boxTopRightCorner = new Vector2(transform.position.x + boxSize, transform.position.y + boxSize);
        Vector2 boxBottomLeftCorner = new Vector2(transform.position.x - boxSize, transform.position.y - boxSize);
        Vector2 boxBottomRightCorner = new Vector2(transform.position.x + boxSize, transform.position.y - boxSize);

        Debug.DrawLine(boxTopLeftCorner, boxTopRightCorner, Color.white);
        Debug.DrawLine(boxTopRightCorner, boxBottomRightCorner, Color.white);
        Debug.DrawLine(boxBottomRightCorner, boxBottomLeftCorner, Color.white);
        Debug.DrawLine(boxBottomLeftCorner, boxTopLeftCorner, Color.white);

    }

    public void SetBoxSize(float newBoxSize)
    {

        boxSize = newBoxSize;

    }

}
