using System;
using Unity.Mathematics;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public GameObject pPaddle;
    public GameObject bPaddle;
    public GameObject topBound;
    public GameObject bottomBound;
    public Rigidbody2D body;

    System.Random rand = new System.Random();
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        pPaddle = GameObject.FindGameObjectWithTag("playerPaddle");
        bPaddle = GameObject.FindGameObjectWithTag("botPaddle");
        topBound = GameObject.FindGameObjectWithTag("topBound");
        bottomBound = GameObject.FindGameObjectWithTag("bottomBound");

        directionsStart();
    }

    // Update is called once per frame
    void Update()
    {
        resetAndPoint();
    }

    private void directionsStart()
    {
        speed = Menu.speed;
        gameObject.transform.position = new Vector3(0, 0, 0);

        float x;
        int rn = rand.Next(0, 2);
        Debug.Log($"Random X-direction: {rn}");
        if (rn == 1)
            x = UnityEngine.Random.Range(speed * 0.75f, speed);
        else
            x = UnityEngine.Random.Range(-speed, speed * -0.75f);

        float y;
        rn = rand.Next(0, 2);
        Debug.Log($"Random Y-direction: {rn}");
        if (rn == 1)
            y = -math.sqrt((speed * speed) - (x * x));
        else
            y = math.sqrt((speed * speed) - (x * x));
        body.velocity = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.Equals(topBound))       
            body.velocity = new Vector2(body.velocity.x, -speed);
        else if (collision.gameObject.Equals(bottomBound))    
            body.velocity = new Vector2(body.velocity.x, speed);
        if (collision.gameObject.Equals(pPaddle))
            body.velocity = new Vector2 (speed * 1.5f, body.velocity.y);
        else if (collision.gameObject.Equals(bPaddle))
            body.velocity = new Vector2(-speed * 1.5f, body.velocity.y);
    }

    private void resetAndPoint()
    {
        if (gameObject.transform.position.x > 10)
        {
            pongLogic.addScoreToPlayer();
            Start();
        }
        else if (gameObject.transform.position.x < -10)
        {
            pongLogic.addScoreToBot();
            Start();
        }
    }
}
