using UnityEngine;
using System.Collections;

public class SpeedlineMover : MonoBehaviour {

    public float speedModifier = 1;
    private float speed;
    public float scaleModifier = 0.05f;
    public float speedlineMinHeight = -8;
    public float speedlineMaxHeight = 8;
    SpriteRenderer sr;
    ApacheEffect ae;
    void Awake()
    {
        speed = speedModifier;
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        ae = GameObject.FindGameObjectWithTag("GameController").GetComponent<ApacheEffect>();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -11)
        {
            transform.position = new Vector2(11, Random.Range(speedlineMinHeight, speedlineMaxHeight));
            SetValues(Random.Range(5, 20));
        }
    }

    public void SetValues(int order)
    {
        this.sr.sortingOrder = order - 100;
        this.speed = order * speedModifier;
        transform.localScale = new Vector3(order * scaleModifier * 4, order * scaleModifier, 1);
    }
}

