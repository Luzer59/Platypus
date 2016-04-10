using UnityEngine;
using System.Collections;

public class ApacheMover : MonoBehaviour {

    public float rotateSpeed = 2;
    public float speedModifier = 1;
    private float speed;
    public float scaleModifier = 0.01f;
    SpriteRenderer sr;
    ApacheEffect ae;

	void Awake ()
    {
        speed = speedModifier;
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        ae = GameObject.FindGameObjectWithTag("GameController").GetComponent<ApacheEffect>();
    }
	
	void Update ()
    {
        //transform.Rotate(Vector3.back, rotateSpeed);
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        if (transform.position.x > 11)
        {
            transform.position = new Vector2(-11, Random.Range((float)ae.apacheMinHeight, (float)ae.apacheMaxHeight));
            SetValues(Random.Range(5, 20));
        }
	}

    public void SetValues(int order)
    {
        this.sr.sortingOrder = order;
        this.speed = order * speedModifier;
        transform.localScale = new Vector3(order * scaleModifier, order * scaleModifier, 1);
        //transform.Rotate(Vector3.back, Random.Range(1, 40));
        if (Random.Range(0,2) == 0)
        {
            this.sr.flipX = false;
        }
        else
        {
            this.sr.flipX = true;
        }
    }
}
