using UnityEngine;
using System;

public class botMovement : MonoBehaviour
{
    public GameObject closestBall;
    public bool direction = false;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        botTrackingMovement();
    }

    private void botMoving(GameObject closestBall)
    {
        if (closestBall.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
            
        } 
        else if (closestBall.transform.position.y < gameObject.transform.position.y)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
            
        }
    }

    private void botTrackingMovement()
    {
        
        closestBall = pongLogic.ballMovements[0];

        for (int i = 1; i < Menu.amount; i++)
        {
            if (pongLogic.ballMovements[i].transform.position.x > closestBall.transform.position.x)
            {
                closestBall = pongLogic.ballMovements[i];
            }
        }

        botMoving(closestBall);
    }
}
