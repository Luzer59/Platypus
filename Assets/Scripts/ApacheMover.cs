using UnityEngine;
using System.Collections;

public class ApacheMover : MonoBehaviour {


    public float speedModifier = 1;
    private float speed;
    public float scaleModifier = 0.05f;
    SpriteRenderer sr;

	void Awake ()
    {
        speed = speedModifier;
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (transform.position.x > 11)
        {
            transform.position = new Vector2(-11, Random.Range(-3.5f, 3.5f)); //<- poista purkka myöhemmin
            SetValues(Random.Range(5, 20));
        }
	}

    public void SetValues(int order)
    {
        this.sr.sortingOrder = order;
        this.speed = order * speedModifier;
        transform.localScale = new Vector3(order * scaleModifier, order * scaleModifier, 1);
    }
}
