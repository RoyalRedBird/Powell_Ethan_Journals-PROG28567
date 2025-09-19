using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    Vector3 velocity = Vector3.zero;
    public float MaxSpeed;
    public float accellTime;

    float updateWaypointTimer = 0;
    public float updateTimeMax = 3;

    Vector3 refPointTopLeft;
    Vector3 refPointBottomRight;

    [SerializeField] Transform playerPos;
    Vector2 travelWaypoint;

    private void Start()
    {

        refPointTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight));
        refPointBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0));
        refreshWaypoint();

    }

    private void Update()
    {

        updateWaypointTimer += Time.deltaTime;

        if(updateWaypointTimer >= updateTimeMax)
        {

            updateWaypointTimer = 0;
            refreshWaypoint();

        }

        EnemyMovement();

        Debug.DrawLine(transform.position, travelWaypoint, Color.green);
        Debug.DrawLine(refPointTopLeft, refPointBottomRight, Color.red);

    }

    void EnemyMovement()
    {


        if (transform.position.x >= travelWaypoint.x)
        {

            velocity.x -= (MaxSpeed / accellTime) * Time.deltaTime;

        }

        if (transform.position.x <= travelWaypoint.x)
        {

            velocity.x += (MaxSpeed / accellTime) * Time.deltaTime;

        }

        if (transform.position.y >= travelWaypoint.y)
        {

            velocity.y -= (MaxSpeed / accellTime) * Time.deltaTime;

        }

        if (transform.position.y <= travelWaypoint.y)
        {

            velocity.y += (MaxSpeed / accellTime) * Time.deltaTime;

        }

        Vector3.ClampMagnitude(velocity, MaxSpeed);

        //Clues were gathered from this forum post. https://discussions.unity.com/t/how-to-detect-screen-edge-in-unity/459224
        //It pointed out using Camera.WorldToScreenPoint to track where the ship is on screen and I thought it fitting.
        if (Camera.main.WorldToScreenPoint(transform.position + velocity).x >= Camera.main.pixelWidth || Camera.main.WorldToScreenPoint(transform.position + velocity).x <= 0)
        {

            velocity.x = 0;

        }

        if (Camera.main.WorldToScreenPoint(transform.position + velocity).y >= Camera.main.pixelHeight || Camera.main.WorldToScreenPoint(transform.position + velocity).y <= 0)
        {

            velocity.y = 0;

        }

        transform.position += velocity;

    }

    void refreshWaypoint()
    {

        Vector3 newWaypoint = playerPos.position;

        newWaypoint.x += Random.Range(-2f, 2f);
        newWaypoint.y += Random.Range(-2f, 2f);

        if (newWaypoint.x < refPointTopLeft.x)
        {

            newWaypoint.x = refPointTopLeft.x;

        }

        if (newWaypoint.x > refPointBottomRight.x)
        {

            newWaypoint.x = refPointBottomRight.x;

        }

        if (newWaypoint.y > refPointTopLeft.y)
        {

            newWaypoint.y = refPointTopLeft.y;

        }

        if (newWaypoint.y < refPointBottomRight.y)
        {

            newWaypoint.y = refPointBottomRight.y;

        }

        travelWaypoint = newWaypoint;

    }

}
