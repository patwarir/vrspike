using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private float randomRange = 0.2f;

    private GameObject ball;

    void createBall()
    {
        ball = Instantiate(ballPrefab);
        float x_offset = Random.Range(-randomRange, randomRange);
        float z_offset = Random.Range(-randomRange, randomRange);
        ball.transform.position = new Vector3(transform.position.x + x_offset, transform.position.y, transform.position.z + z_offset);
    }

    private void Update()
    {
        if (!ball)
        {
            createBall();
        }
        else
        {
            if (ball.transform.position.magnitude > 12)
            {
                Destroy(ball);
                ball = null;
            }
        }
        
    }
}
