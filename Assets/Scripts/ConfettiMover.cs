using UnityEngine;
using System.Collections;

public class ConfettiMover : MonoBehaviour {

    float maxSpeed;
    float minSpeed;
    float speed;

    bool spawned = false;

    Vector3 direction;
    Transform spawnPoint;
    Rigidbody rb;


    void Start()
    {
        spawned = true;

        int r = Random.Range(0, 3);
        if (r == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, Random.Range(0f, 1f), 1f);
        }
        else if (r == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, Random.Range(0f, 1f), 1f);
        }
        else if (r == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), 1f, 0f, 1f);
        }

        rb = GetComponent<Rigidbody>();
        direction = new Vector3(spawnPoint.position.x + Random.Range(-15, 15), 15, spawnPoint.position.z).normalized;
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = direction * speed;
    }
	
    public void SetValues(Transform spawnPoint, float maxSpeed, float minSpeed)
    {
        this.spawnPoint = spawnPoint;
        this.maxSpeed = maxSpeed;
        this.minSpeed = minSpeed;
    }
}
