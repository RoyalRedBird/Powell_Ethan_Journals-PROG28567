using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed;
    public float orbitRadius;
    [SerializeField] float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        OrbitHandler(orbitRadius, orbitSpeed);

    }

    void OrbitHandler(float radius, float speed)
    {

        float angleIncrement = speed * Time.deltaTime;
        float incrementAsRadians = angleIncrement * Mathf.Deg2Rad;
        currentAngle += angleIncrement;

        Vector3 currentPos = planetTransform.position;
        currentPos += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle)) * radius;

        transform.position = currentPos;

    }

}
