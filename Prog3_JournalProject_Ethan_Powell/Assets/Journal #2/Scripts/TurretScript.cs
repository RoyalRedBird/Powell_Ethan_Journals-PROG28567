using UnityEngine;

public class TurretScript : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 15f;
    [SerializeField] Transform targetToTrack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        float angleToTarget = CalculateDegAngleFromVector(targetToTrack.position);

        Vector2 easyTargetDir = (targetToTrack.position - transform.position).normalized;

        Debug.DrawLine(transform.position, easyTargetDir, Color.red);
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.cyan);

        float upAngle = CalculateDegAngleFromVector(transform.up);
        float deltaAngle = Mathf.DeltaAngle(upAngle, angleToTarget);

        float sign = Mathf.Sign(deltaAngle);

        float rotateSpeed = rotationSpeed * Time.deltaTime * sign;

        if (Mathf.Abs(rotateSpeed) < Mathf.Abs(deltaAngle))
        {

            transform.Rotate(0f, 0f, rotateSpeed, Space.Self);

        }
        else {

            transform.Rotate(0f, 0f, deltaAngle, Space.Self);

        }



        if (Vector2.Dot(transform.up, easyTargetDir) > 0)
        {

            //Debug.Log("Target is in front of the turret.");

        }
        else
        {

            //Debug.Log("Target is behind the turret.");

        }

    }

    private float CalculateDegAngleFromVector(Vector2 vec) {

        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

    }

}
