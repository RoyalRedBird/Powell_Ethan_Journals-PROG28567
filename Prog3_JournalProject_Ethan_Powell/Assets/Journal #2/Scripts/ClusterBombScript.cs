using UnityEngine;

public class ClusterBombScript : MonoBehaviour
{

    [SerializeField] int recursionsLeft = 0;
    [SerializeField] int bombletsToDeploy = 0;
    [SerializeField] float bombTimer = 3f;
    float currentTime = 0;
    [SerializeField] private GameObject bomb;
    Vector3 currentHeading = Vector3.zero;
    float currentSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = bombTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime -= Time.deltaTime;

        transform.position += (currentHeading) * currentSpeed * Time.deltaTime;

        if (currentTime <= 0) {

            if (recursionsLeft > 0)
            {

                BombExplode();
                GameObject.Destroy(gameObject);

            }
            else if (recursionsLeft == 0)
            {

                GameObject.Destroy(gameObject);

            }

        }

    }

    void BombExplode() { 
    
        for(int i = 0; i < bombletsToDeploy; i++)
        {

            GameObject newBomb = GameObject.Instantiate(bomb);
            newBomb.transform.position = transform.position;

            newBomb.GetComponent<ClusterBombScript>().InitializeNewBomb(recursionsLeft, bombletsToDeploy, bombTimer);

        }

    }

    public void InitializeNewBomb(int recursions, int bomblets, float bombTimer) { 
    
        recursionsLeft = recursions - 1;
        bombletsToDeploy = bomblets;
        bombTimer = bombTimer / 2;

        float randomAngleInRad = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        currentHeading = new Vector2(Mathf.Cos(randomAngleInRad), Mathf.Sin(randomAngleInRad)).normalized;
        currentSpeed = Random.Range(1f, 3f);

    }

}
