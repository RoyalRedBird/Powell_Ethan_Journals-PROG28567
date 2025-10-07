using UnityEngine;

public class DotProdTestScript : MonoBehaviour
{

    [SerializeField] float redAngle = 0;
    [SerializeField] float blueAngle = 0;

    Vector2 redVector;
    Vector2 blueVector;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        redVector = CalculateVectorFromAngle(redAngle);
        blueVector = CalculateVectorFromAngle(blueAngle);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space)) { 
        
            DotValueCalc();
        
        }

    }

    Vector2 CalculateVectorFromAngle(float angle) { 
    
        float angleAsRad = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angleAsRad), Mathf.Sin(angleAsRad)) * 1;

    }

    void DotValueCalc() {

        float dotValue = redVector.x * blueVector.x + redVector.y * blueVector.y;
        Debug.Log(dotValue);
    
    }

}
